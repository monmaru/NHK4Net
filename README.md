# NHK4Net
[![Build status](https://ci.appveyor.com/api/projects/status/66x3hux7575h1x8d?svg=true)](https://ci.appveyor.com/project/monmaru/nhk4net)  
This is a [NHK番組表API](http://api-portal.nhk.or.jp/) client library for C#.  

## Dev
Visual Studio 2017  

## Requirements
.Net Framework 4.5+

## Install
```
PM> Install-Package NHK4Net
```
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
