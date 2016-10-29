using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.EPS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CSV_Inventory_Bobby
{
    class eBayup
    {
        public static ApiContext apiContext;
        private static StringCollection sizefound;
        private static StringCollection colorfound;
        private static bool nonexist;
        private static bool skip;
        private static bool builditem;
        public static double feeamount;
        public bool auto;
        public bool revised;
        public bool revisei;
        private static string token = "";
        public static SiteCodeType country;
        public eBayup(string tokenref, SiteCodeType code)
        {
            eBayup.country = code;
            eBayup.token = tokenref;
            eBayup.nonexist = false;
            eBayup.apiContext = eBayup.GetApiContext();
            eBayup.sizefound = new StringCollection();
            eBayup.colorfound = new StringCollection();
            eBayup.skip = false;
            eBayup.builditem = false;
            eBayup.feeamount = 0.0;
        }

        private static ApiContext GetApiContext()
        {
            if (eBayup.apiContext != null)
            {
                return eBayup.apiContext;
            }
            eBayup.apiContext = new ApiContext();
            eBayup.apiContext.SoapApiServerUrl = ConfigurationManager.AppSettings["Environment.ApiServerUrl"];
            ApiCredential apiCredential = new ApiCredential();
            ApiAccount account = new ApiAccount("TOKEN INFO");
            apiCredential.ApiAccount = account;
            eBayup.apiContext.ApiCredential = apiCredential;
            eBayup.apiContext.Site = eBayup.country;
            eBayup.apiContext.SignInUrl = "https://signin.ebay.com/ws/eBayISAPI.dll?SignIn";
            eBayup.apiContext.EPSServerUrl = "https://api.ebay.com/ws/api.dll";
            eBayup.apiContext.ApiCredential.eBayToken = eBayup.token;
            return eBayup.apiContext;
        }

        public string Execute(string title, string SKU, string Description, double StartPrice, int quantity, string Size, string Color, string Model, int LBS, int OZ, string modelwo)
        {
            bool revise = false;
            bool search = true;
            if (search)
            {
                eBayup.colorfound = eBayup.Search("color", Model);
                if (eBayup.colorfound == null && eBayup.nonexist)
                {
                    eBayup.skip = true;
                }
                eBayup.sizefound = eBayup.Search("size", Model);
                if (eBayup.sizefound == null && eBayup.nonexist)
                {
                    eBayup.skip = true;
                }
                if (!eBayup.skip)
                {
                    revise = true;
                }
            }
            if (revise)
            {
                try
                {
                    ItemType item = eBayup.reviseItem(Model, eBayup.sizefound, eBayup.colorfound, Color, Size, StartPrice, SKU, quantity, Description, this.revised, this.revisei);
                    StringCollection deletedFields = new StringCollection();
                    ReviseFixedPriceItemCall apiCall = new ReviseFixedPriceItemCall(eBayup.apiContext);
                    FeeTypeCollection fees = apiCall.ReviseFixedPriceItem(item, deletedFields);
                    double listingFee = 0.0;
                    foreach (FeeType fee in fees)
                    {
                        if (fee.Name == "ListingFee")
                        {
                            listingFee = fee.Fee.Value;
                        }
                    }
                    eBayup.feeamount = listingFee;
                    string result = "success";
                    return result;
                }
                catch (System.Exception ex)
                {
                    if (ex.Message == "There is no active item matching the specified SKU")
                    {
                        revise = false;
                    }
                    else
                    {
                        xmlread read = new xmlread();
                        System.Collections.Generic.IEnumerator<XNode> enodes = read.read();
                        string error = ex.Message;
                        string result;
                        if (this.auto)
                        {
                            result = "skip";
                            return result;
                        }
                        if (read.contains(enodes, error))
                        {
                            result = "skip";
                            return result;
                        }
                        alert alert = new alert();
                        bool yesclicked = alert.Show(string.Format("ERROR: {0} \r\n An Item Has To Be Skipped do to Error! Do you want to abort?", ex.Message), true);
                        bool isChecked = alert.getChecked();
                        if (isChecked)
                        {
                            new xmlwrite(ex.Message);
                        }
                        if (yesclicked)
                        {
                            result = "close";
                            return result;
                        }
                        if (alert.auto)
                        {
                            this.auto = true;
                        }
                        result = "skip";
                        return result;
                    }
                }
            }
            if (!revise)
            {
                eBayup.builditem = true;
            }
            if (eBayup.builditem)
            {
                try
                {
                    string result;
                    if (quantity > 0)
                    {
                        if (title.Length >= 55)
                        {
                            title = title.Substring(0, 55);
                        }
                        ItemType item2 = eBayup.BuildItem(title, SKU, Description, StartPrice, quantity, Size, Color, Model, LBS, OZ, modelwo);
                        AddFixedPriceItemCall apiCall2 = new AddFixedPriceItemCall(eBayup.apiContext);
                        FeeTypeCollection fees2 = apiCall2.AddFixedPriceItem(item2);
                        double listingFee2 = 0.0;
                        foreach (FeeType fee2 in fees2)
                        {
                            if (fee2.Name == "ListingFee")
                            {
                                listingFee2 = fee2.Fee.Value;
                            }
                        }
                        if (apiCall2.ApiResponse.Message != null)
                        {
                            alert alerter = new alert();
                            alerter.Show(string.Format("{0}", apiCall2.ApiResponse.Message), true);
                        }
                        eBayup.feeamount = listingFee2;
                        result = "success";
                        return result;
                    }
                    result = "success";
                    return result;
                }
                catch (System.Exception exp)
                {
                    xmlread read2 = new xmlread();
                    System.Collections.Generic.IEnumerator<XNode> enodes2 = read2.read();
                    string error2 = exp.Message;
                    string result;
                    if (read2.contains(enodes2, error2))
                    {
                        result = "skip";
                        return result;
                    }
                    if (this.auto)
                    {
                        result = "skip";
                        return result;
                    }
                    alert alert2 = new alert();
                    bool yesclicked2 = alert2.Show(string.Format("ERROR: {0} \r\n An Item Has To Be Skipped do to Error! Do you want to abort?", exp.Message), true);
                    bool isChecked2 = alert2.getChecked();
                    if (isChecked2)
                    {
                        new xmlwrite(exp.Message);
                    }
                    if (yesclicked2)
                    {
                        result = "close";
                        return result;
                    }
                    if (alert2.auto)
                    {
                        this.auto = true;
                    }
                    result = "skip";
                    return result;
                }
            }
            return "skip";
        }

        private static StringCollection Search(string type, string sku)
        {
            try
            {
                GetItemCall search = new GetItemCall(eBayup.apiContext);
                search.ApiRequest = new GetItemRequestType
                {
                    SKU = sku,
                    ErrorLanguage = "en_US",
                    Version = "691"
                };
                search.Execute();
                GetItemResponseType response = new GetItemResponseType();
                response = search.ApiResponse;
                ItemType item = new ItemType();
                item = response.Item;
                NameValueListTypeCollection var = item.Variations.VariationSpecificsSet;
                foreach (NameValueListType variation in var)
                {
                    if (type == "color" && variation.Name == "Color")
                    {
                        StringCollection colors = new StringCollection();
                        colors = variation.Value;
                        StringCollection result = colors;
                        return result;
                    }
                    if (type == "size" && variation.Name == "Size")
                    {
                        StringCollection sizes = new StringCollection();
                        sizes = variation.Value;
                        StringCollection result = sizes;
                        return result;
                    }
                }
            }
            catch (System.Exception ex)
            {
                if (ex.Message == "There is no active item matching the specified SKU")
                {
                    eBayup.nonexist = true;
                }
                else
                {
                    MessageBox.Show(string.Format("ERROR: {0}", ex.Message), "ERROR");
                }
            }
            return null;
        }

        private static ItemType BuildItem(string title, string SKU, string Description, double StartPrice, int quantity, string Size, string Color, string Model, int LBS, int OZ, string modelwo)
        {
            ItemType item = new ItemType();
            item.Title = title;
            item.Description = Description;
            item.HitCounter = HitCounterCodeType.BasicStyle;
            item.ListingType = ListingTypeCodeType.FixedPriceItem;
            item.Currency = CurrencyCodeType.USD;
            item.StartPrice = new AmountType();
            item.StartPrice.Value = StartPrice;
            item.StartPrice.currencyID = CurrencyCodeType.USD;
            item.ListingDuration = "GTC";
            item.Location = "Westport";
            item.Country = CountryCodeType.US;
            item.PrimaryCategory = new CategoryType
            {
                CategoryID = "313"
            };
            item.Quantity = quantity;
            item.PaymentMethods = new BuyerPaymentMethodCodeTypeCollection();
            item.PaymentMethods.AddRange(new BuyerPaymentMethodCodeType[]
			{
				BuyerPaymentMethodCodeType.PayPal
			});
            item.PayPalEmailAddress = "elliesox@optonline.net";
            item.ConditionID = 1000;
            item.DispatchTimeMax = 3;
            item.ShippingDetails = eBayup.BuildShippingDetails(LBS, OZ);
            item.ReturnPolicy = new ReturnPolicyType
            {
                ReturnsWithinOption = "Days_14",
                ReturnsAcceptedOption = "ReturnsAccepted",
                Description = "IF YOU ARE NOT FULLY SATISFIED, I OFFER AN UNCONDITIONAL FULL MONEY BACK GUARANTEE, EXCLUSIVE OF SHIPPING COSTS."
            };
            item.PostalCode = "06880";
            StringCollection originalsize = new StringCollection();
            StringCollection originalcolor = new StringCollection();
            item.Variations = eBayup.BuildVariations(Size, Color, StartPrice, SKU, quantity, originalcolor, originalsize);
            item.UseTaxTable = true;
            item.InventoryTrackingMethod = InventoryTrackingMethodCodeType.SKU;
            item.SKU = Model;
            imageread read = new imageread();
            System.Collections.Generic.IEnumerator<XNode> node = read.read();
            bool contains = read.contains(node, Model);
            if (contains)
            {
                PictureDetailsType pic = new PictureDetailsType();
                StringCollection collection = new StringCollection();
                eBayPictureService pics = new eBayPictureService(eBayup.apiContext);
                string file = pics.UpLoadPictureFile(PhotoDisplayCodeType.None, read.imagepath);
                collection.Add(file);
                pic.PictureURL = collection;
                item.PictureDetails = pic;
            }
            return item;
        }

        private static ShippingDetailsType BuildShippingDetails(int LBS, int OZ)
        {
            ShippingDetailsType sd = new ShippingDetailsType();
            sd.ApplyShippingDiscount = true;
            AmountType amount = new AmountType();
            amount.Value = 5.99;
            amount.currencyID = CurrencyCodeType.USD;
            sd.PaymentInstructions = "";
            sd.ShippingType = ShippingTypeCodeType.FlatDomesticCalculatedInternational;
            ShippingServiceOptionsType shippingOptions = new ShippingServiceOptionsType();
            shippingOptions.ShippingService = ShippingServiceCodeType.UPSGround.ToString();
            InternationalShippingServiceOptionsType intShippingOptions = new InternationalShippingServiceOptionsType();
            intShippingOptions.ShippingService = ShippingServiceCodeType.USPSFirstClassMailInternational.ToString();
            InternationalShippingServiceOptionsType intShippingOptions2 = new InternationalShippingServiceOptionsType();
            intShippingOptions2.ShippingService = ShippingServiceCodeType.USPSPriorityMailInternational.ToString();
            intShippingOptions.ShippingServicePriority = 2;
            intShippingOptions2.ShippingServicePriority = 3;
            StringCollection code = new StringCollection();
            code.Add("Worldwide");
            intShippingOptions.ShipToLocation = code;
            intShippingOptions2.ShipToLocation = code;
            shippingOptions.ShippingServiceAdditionalCost = new AmountType
            {
                Value = 1.0,
                currencyID = CurrencyCodeType.USD
            };
            MeasureType measure = new MeasureType();
            measure.measurementSystem = MeasurementSystemCodeType.English;
            measure.unit = "lbs";
            measure.Value = LBS;
            sd.CalculatedShippingRate = new CalculatedShippingRateType
            {
                WeightMajor = measure,
                WeightMinor = new MeasureType
                {
                    measurementSystem = MeasurementSystemCodeType.English,
                    unit = "oz",
                    Value = OZ
                },
                InternationalPackagingHandlingCosts = new AmountType
                {
                    Value = 5.0,
                    currencyID = CurrencyCodeType.USD
                }
            };
            shippingOptions.ShippingServiceCost = new AmountType
            {
                Value = 5.99,
                currencyID = CurrencyCodeType.USD
            };
            shippingOptions.ShippingServicePriority = 1;
            shippingOptions.ShippingSurcharge = new AmountType
            {
                Value = 2.5,
                currencyID = CurrencyCodeType.USD
            };
            amount = new AmountType();
            amount.Value = 5.0;
            sd.ShippingServiceOptions = new ShippingServiceOptionsTypeCollection(new ShippingServiceOptionsType[]
			{
				shippingOptions
			});
            sd.InternationalShippingServiceOption = new InternationalShippingServiceOptionsTypeCollection(new InternationalShippingServiceOptionsType[]
			{
				intShippingOptions, 
				intShippingOptions2
			});
            return sd;
        }

        private static VariationsType BuildVariations(string sizea, string colora, double price, string sku, int quantity, StringCollection orignialcolor, StringCollection originalsize)
        {
            VariationsType vts = new VariationsType();
            VariationType vt = new VariationType();
            vt.Quantity = quantity;
            vt.SKU = sku;
            vt.StartPrice = new AmountType
            {
                currencyID = CurrencyCodeType.USD,
                Value = price
            };
            NameValueListType mastersize = new NameValueListType();
            mastersize.Name = "Size";
            StringCollection mastervalue = new StringCollection();
            mastervalue = eBayup.addToMasterVariation(sizea, originalsize);
            mastersize.Value = mastervalue;
            NameValueListType mastercolor = new NameValueListType();
            mastercolor.Name = "Color";
            StringCollection mastercolorvalue = new StringCollection();
            mastercolorvalue = eBayup.addToMasterVariation(colora, orignialcolor);
            mastercolor.Value = mastercolorvalue;
            NameValueListType size = new NameValueListType();
            size = eBayup.CreateVariation("Size", sizea);
            NameValueListType color = new NameValueListType();
            color = eBayup.CreateVariation("Color", colora);
            vts.VariationSpecificsSet = new NameValueListTypeCollection(new NameValueListType[]
			{
				mastersize, 
				mastercolor
			});
            vt.VariationSpecifics = eBayup.CreateNameValueListTypeCollection(size, color);
            vts.Variation = new VariationTypeCollection(new VariationType[]
			{
				vt
			});
            return vts;
        }

        private static StringCollection addToMasterVariation(string value, StringCollection collection)
        {
            if (collection != null)
            {
                if (collection.Contains(value))
                {
                    return collection;
                }
                collection.Add(value);
            }
            return collection;
        }

        private static NameValueListType CreateVariation(string name, string value)
        {
            return new NameValueListType
            {
                Name = name,
                Value = new StringCollection
				{
					value
				}
            };
        }

        private static NameValueListTypeCollection CreateNameValueListTypeCollection(NameValueListType size, NameValueListType color)
        {
            return new NameValueListTypeCollection(new NameValueListType[]
			{
				size, 
				color
			});
        }

        private static ItemType reviseItem(string SKU, StringCollection originalsize, StringCollection originalcolor, string newcolor, string newsize, double price, string upc, int quantity, string description, bool locrevised, bool locrevisi)
        {
            ItemType item = new ItemType();
            item.SKU = SKU;
            item.Variations = eBayup.BuildVariations(newsize, newcolor, price, upc, quantity, originalcolor, originalsize);
            if (locrevised)
            {
                item.Description = description;
            }
            if (locrevisi)
            {
                imageread read = new imageread();
                System.Collections.Generic.IEnumerator<XNode> node = read.read();
                bool contains = read.contains(node, SKU);
                if (contains)
                {
                    PictureDetailsType pic = new PictureDetailsType();
                    StringCollection collection = new StringCollection();
                    eBayPictureService pics = new eBayPictureService(eBayup.apiContext);
                    string file = pics.UpLoadPictureFile(PhotoDisplayCodeType.None, read.imagepath);
                    collection.Add(file);
                    pic.PictureURL = collection;
                    item.PictureDetails = pic;
                }
            }
            return item;
        }

        public double getFee()
        {
            return eBayup.feeamount;
        }
    }
}
