# Dynamic-API

Is a simple non-production API that is ideal to deploy on a local or cloud machine. It's main purpose is making client testing easy. 

Type of model used:
```json
{
Name: "Model Name",
ExtraElements: {
    //Anythig goes here
  }
}
```

> :warning: **ExtraElements supports any kind of JSON datatypes.**


How to use:
- Add a model to the database using "/create" endpoint (Adding again a model with the same name, will override the old model);
- Retrieve the model by using the name or the id;
- Delete single model, or clean the database after you are done testing (No securrity it's added to the API as it is intended for testing purpose);

For anything related to this project you can drop me a message at: __alexandru[at]oprean.net__
