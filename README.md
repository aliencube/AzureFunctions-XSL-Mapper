# AzureFunctions XSL Mapper #

This is an XSL mapper written in Azure Functions as an alternative to Azure Integration Account.


## More Readings ##

* 한국어: TBD
* English: TBD


## Getting Started ##

### Configuration ###

The following information should be configured:

* `Containers__Mappers`: Container name for the mapper
* `Containers__ExtensionObjects`: Container name for the extension objects
* `EncodeBase64Output`: Value indicating whether to encode the output XML string in base-64 format or not. Default is `false`.


### Payload Structure ###

Use the following payload structure for request.

```json
{
  "inputXml": "<ESCAPED XML=\"STRING\" />",
  "mapper": {
    "directory": "[DIRECTORY NAME IN THE CONTAINER]",
    "name": "XSL_MAPPER_NAME.xsl"
  },
  "extensionObjects": [
    {
      "directory": "[DIRECTORY NAME IN THE CONTAINER]",
      "name": "LIBRARY.dll",
      "namespace": "http://schemas.microsoft.com/BizTalk/2003/NAMESPACE",
      "assemblyName": "Fully.Qualified.Assembly.Name, Version=1.0.0.0, Culture=neutral, PublicKeyToken=d7e94ac1875c97e9",
      "className": "Fully.Qualified.Class.Name"
    }
  ]
}
```

* `inputXml`: XML string for transformation.
* `mapper`: Metadata information of XSL used for transformation.
* `extensionObjects`: Metadata information of external objects referenced by the XSL file.


### XSL and Library Storage ##

Both XSL files and library files (.dll files) are uploaded to the designated blob storage. Default container locations are:

* Mappers: `mappers`
* Extension Objects: `extensionobjects`


## Contribution ##

Your contributions are always welcome! All your work should be done in your forked repository. Once you finish your work with corresponding tests, please send us a pull request onto our `dev` branch for review.


## License ##

**AzureFunctions XSL Mapper** is released under [MIT License](http://opensource.org/licenses/MIT)

> The MIT License (MIT)
>
> Copyright (c) 2019 [aliencube.org](http://aliencube.org)
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
