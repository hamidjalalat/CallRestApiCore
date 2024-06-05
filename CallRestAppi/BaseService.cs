using Newtonsoft.Json;

namespace CallRestAppi
{
    public abstract class BaseService
    {
        public BaseService(HttpClient http)
        {

            Http = http;
            RequestUri = $"{BaseUrl}/{GetApiUrl()}";

        }

        protected string? BaseUrl { get; set; }

        protected string RequestUri { get; set; }

        protected abstract string GetApiUrl();

        protected HttpClient Http { get; set; }

        protected virtual async Task<O> GetAsync<O>()
        {
            HttpResponseMessage response = null;

            //response.Headers.Add("AuthenticationToken", "");

            try
            {
                response = await Http.GetAsync(requestUri: RequestUri);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        O result =
                            await response.Content.ReadFromJsonAsync<O>();

                        return result;
                    }

                    catch (NotSupportedException)
                    {
                       //insert log
                    }

                    catch (JsonException)
                    {
                      //insert log
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                //insert log
            }
            finally
            {
                response.Dispose();
            }

            return default;
        }

        protected virtual async Task<O> GetAsyncById<O>(string id)
        {
            HttpResponseMessage response = null;

            try
            {
                response = await Http.GetAsync(requestUri: RequestUri + $"/{id}");

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        O result = await response.Content.ReadFromJsonAsync<O>();

                        return result;
                    }

                    catch (System.NotSupportedException)
                    {
                        //inserlog
                    }

                    catch (System.Text.Json.JsonException)
                    {
                        //inserlog
                    }
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                //inserlog
            }
            finally
            {
                response.Dispose();
            }

            return default;
        }

        protected virtual async Task<O> PostAsync<I, O>(I viewModel)
        {
            HttpResponseMessage response = null;

            try
            {
                response = await Http.PostAsJsonAsync(requestUri: RequestUri, value: viewModel);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    try
                    {

                        O result = await response.Content.ReadFromJsonAsync<O>();

                        return result;

                    }

                    catch (System.NotSupportedException)
                    {
                        //inserlog
                    }

                    catch (System.Text.Json.JsonException)
                    {
                        //inserlog
                    }
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                // Invalid JSON
            }
            finally
            {
                response.Dispose();
            }

            return default;
        }
    }
}
