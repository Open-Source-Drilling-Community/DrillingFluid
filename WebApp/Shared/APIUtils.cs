public static class APIUtils
{
    // API parameters
    public static readonly string HostNameDrillingFluid = NORCE.Drilling.DrillingFluid.WebApp.Configuration.DrillingFluidHostURL!;
    public static readonly string HostBasePathDrillingFluid = "DrillingFluid/api/";
    public static readonly HttpClient HttpClientDrillingFluid = APIUtils.SetHttpClient(HostNameDrillingFluid, HostBasePathDrillingFluid);
    public static readonly NORCE.Drilling.DrillingFluid.ModelShared.Client ClientDrillingFluid = new NORCE.Drilling.DrillingFluid.ModelShared.Client(APIUtils.HttpClientDrillingFluid.BaseAddress!.ToString(), APIUtils.HttpClientDrillingFluid);

    public static readonly string HostNameUnitConversion = NORCE.Drilling.DrillingFluid.WebApp.Configuration.UnitConversionHostURL!;
    public static readonly string HostBasePathUnitConversion = "UnitConversion/api/";


    public static readonly string HostDevDigiWells = "https://dev.digiwells.no/";
    public static readonly string HostBasePathDrillString = "DrillString/api/";
    public static readonly HttpClient HttpClientDrillString = APIUtils.SetHttpClient(HostDevDigiWells, HostBasePathDrillString);
    public static readonly NORCE.Drilling.DrillingFluid.ModelShared.Client ClientDrillString = new NORCE.Drilling.DrillingFluid.ModelShared.Client(APIUtils.HttpClientDrillString.BaseAddress!.ToString(), APIUtils.HttpClientDrillString);


    // API utility methods
    public static HttpClient SetHttpClient(string host, string microServiceUri)
    {
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }; // temporary workaround for testing purposes: bypass certificate validation (not recommended for production environments due to security risks)
        HttpClient httpClient = new(handler)
        {
            BaseAddress = new Uri(host + microServiceUri)
        };
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        return httpClient;
    }
}