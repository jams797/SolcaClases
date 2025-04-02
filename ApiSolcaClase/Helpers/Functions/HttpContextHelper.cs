namespace ApiSolcaClase.Helpers.Functions
{
    public static class HttpContextHelper
    {
        private static IHttpContextAccessor _httpAc;

        public static void Initialize(IHttpContextAccessor httpAc)
        {
            _httpAc = httpAc;
        }

        public static HttpContext Current => _httpAc?.HttpContext;


        public static T GetItem<T>(string key)
        {
            if (_httpAc.HttpContext == null) return default;
            return _httpAc.HttpContext.Items[key] is T item ? item : default;
        }



        public static void SetItem(string key, object value)
        {
            if( _httpAc.HttpContext != null)
            {
                _httpAc.HttpContext.Items[key] = value;
            }
        }
    }
}
