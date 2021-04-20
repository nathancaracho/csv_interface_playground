# CSV interface Playground

## Todo list

- [x] Implement CSV interface
  - [x]  ~~Implement [WebApiContrib.Core.Formatter.Csv][WebApiContrib] removed~~
  - [x]  Implement [custom formatter][CustomFormater]  
  - [x]  Implement [CSV Helper][CsvHelper]
  - [x]  Create [custom type converter][CustomConverter] to property list
  
- [x] Add [Fluent validation][FluentValidation]
  - [x]  Implement book [collection validator][CollectionValidator]
  - [ ]  Implement async validator

- [ ] Analyze performance tradeoff between JSON converting and CSV converting

- [ ] Document all

  

[WebApiContrib]:https://github.com/WebApiContrib/WebAPIContrib.Core/tree/master/src/WebApiContrib.Core.Formatter.Csv
[CustomFormater]: https://docs.microsoft.com/en-us/aspnet/core/web-api/advanced/custom-formatters?view=aspnetcore-5.0

[CsvHelper]:https://joshclose.github.io/CsvHelper/
[CustomConverter]:https://joshclose.github.io/CsvHelper/examples/configuration/class-maps/type-conversion
[FluentValidation]:https://docs.fluentvalidation.net/en/latest/index.html
[CollectionValidator]:https://docs.fluentvalidation.net/en/latest/collections.html