namespace ManualTestParser
{
    public static class Test_data
    {
        public const string output_file = @"d:\temp\descriptions.xlsx";
        public const string invalid_file = @"w:\bogus\fail.xlsx";
        public const string xml_test_snippet = "<WebAiiTest xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://artoftest.com/schemas/WebAiiDesignCanvas/3.0.0\"> <DataInfo xmlns:d2p1=\"http://artoftest.com/schemas/WebAiiDesignCanvas/1.0.0\"> <d2p1:BuiltInData i:nil=\"true\" /> <d2p1:BuiltInDocumentKey i:nil=\"true\" /> <d2p1:ConnectionString /> <d2p1:DataEnabled>true</d2p1:DataEnabled> <d2p1:DataProvider /> <d2p1:DataRange /> <d2p1:DataTableName /> <d2p1:DataType>None</d2p1:DataType> <d2p1:DefaultToGrid>true</d2p1:DefaultToGrid> <d2p1:HasBuiltinGrid>false</d2p1:HasBuiltinGrid> <d2p1:LoadRecordsCount i:nil=\"true\" /> <d2p1:TSQL /> </DataInfo> <Description /> <IsManual>true</IsManual> <Name>z Validate Form</Name> </WebAiiTest>";
        public const string Valid_small_json = @"
  {
  	'__type': 'ArtOfTest.WebAii.Design.ProjectModel.Test',
  	'__value': {
  		'DomStatesCounter': {},
  		'WebKitExecutionDelay': 0,
  		'IsManual' : true,
  		'Steps' : {
  			'__type': 'ArtOfTest.Common.Design.ProjectModel.AutomationStepList',
  			'__value': [
  			{
  				'__type': 'ArtOfTest.WebAii.Design.ProjectModel.AutomationStep',
  				'__value': {
  					'Runtime ID': '0937b5d1-e56e-4fe3-bddd-f2c6433178b6',
  					'Description': 'aaaa',
  					'CustomDescription': 'bbb'
  				}
  			
  			},
          		{
  			  '__type': 'ArtOfTest.WebAii.Design.ProjectModel.AutomationStep',
  			  '__value': {
  				    'Runtime ID': '45c6ee53-e7cf-4396-bc58-48f6908e8a1d',
  				    'Description': 'ccc',
  				    'CustomDescription': null
  			   }
  			}
             		]
  		}
  	}
  }



  ";

        public const string Invalid_type_small_json = @"{
  '__type': 'Something.bogus',
  '__value': { 
  	'bogus' : 'value' 
  	}
  }";
    }
}