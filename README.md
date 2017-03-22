# NHK4Net
This is a [NHK番組表API](http://api-portal.nhk.or.jp/) client library for C#.

## Dev
Visual Studio 2017

## Example
```csharp
const string apiKey = "YOUR_API_KEY";
try
{
    using (NHKClient nhk = new NHKRestClient(apiKey))
    {
        var programs = await nhk.GetProgramListAsync(NHKArea.東京, NHKService.総合1, DateTime.Today);
        Console.WriteLine(programs.Count());
    }
}
catch (NHKException e)
{
    Console.WriteLine(e.ErrorCode);
    Console.WriteLine(e.Message);
}
```