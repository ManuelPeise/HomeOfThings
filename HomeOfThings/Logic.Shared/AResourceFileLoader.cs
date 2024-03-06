using Data.Ressources;
using Newtonsoft.Json;

namespace Logic.Shared
{
    public abstract class AResourceFileLoader
    {
        public async Task<T?> GetModelFromResourceFile<T>(string resource)
        {
            using(var stream = LoadResource(resource))
            {
                if(stream != null)
                {
                    using(var reader = new StreamReader(stream))
                    {
                        var json = await reader.ReadToEndAsync();

                        if(json != null)
                        {
                            return JsonConvert.DeserializeObject<T>(json);
                        }
                    }
                }
            }

            return default(T);
        }

        private Stream? LoadResource(string resource)
        {
            switch(resource)
            {
                case RessourceNames.BudgetAccountTemplate:
                    return new MemoryStream(Files.Resources.BudgetAccountTemplate);
                default: return null;
            }
        }
    }
}
