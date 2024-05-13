// <auto-generated/>

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Amazon.Lambda.Core;
using Amazon.Lambda.Annotations.APIGateway;

namespace TestServerlessApp
{
    public class CustomizeResponseExamples_NotFoundResponseWithHeaderV1Async_Generated
    {
        private readonly CustomizeResponseExamples customizeResponseExamples;
        private readonly Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer serializer;

        /// <summary>
        /// Default constructor. This constructor is used by Lambda to construct the instance. When invoked in a Lambda environment
        /// the AWS credentials will come from the IAM role associated with the function and the AWS region will be set to the
        /// region the Lambda function is executed in.
        /// </summary>
        public CustomizeResponseExamples_NotFoundResponseWithHeaderV1Async_Generated()
        {
            SetExecutionEnvironment();
            customizeResponseExamples = new CustomizeResponseExamples();
            serializer = new Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer();
        }

        /// <summary>
        /// The generated Lambda function handler for <see cref="NotFoundResponseWithHeaderV1Async(int, Amazon.Lambda.Core.ILambdaContext)"/>
        /// </summary>
        /// <param name="__request__">The API Gateway request object that will be processed by the Lambda function handler.</param>
        /// <param name="__context__">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
        /// <returns>Result of the Lambda function execution</returns>
        public async System.Threading.Tasks.Task<System.IO.Stream> NotFoundResponseWithHeaderV1Async(Amazon.Lambda.APIGatewayEvents.APIGatewayProxyRequest __request__, Amazon.Lambda.Core.ILambdaContext __context__)
        {
            var validationErrors = new List<string>();

            var x = default(int);
            if (__request__.PathParameters?.ContainsKey("x") == true)
            {
                try
                {
                    x = (int)Convert.ChangeType(__request__.PathParameters["x"], typeof(int));
                }
                catch (Exception e) when (e is InvalidCastException || e is FormatException || e is OverflowException || e is ArgumentException)
                {
                    validationErrors.Add($"Value {__request__.PathParameters["x"]} at 'x' failed to satisfy constraint: {e.Message}");
                }
            }

            // return 400 Bad Request if there exists a validation error
            if (validationErrors.Any())
            {
                var errorResult = new Amazon.Lambda.APIGatewayEvents.APIGatewayProxyResponse
                {
                    Body = @$"{{""message"": ""{validationErrors.Count} validation error(s) detected: {string.Join(",", validationErrors)}""}}",
                    Headers = new Dictionary<string, string>
                    {
                        {"Content-Type", "application/json"},
                        {"x-amzn-ErrorType", "ValidationException"}
                    },
                    StatusCode = 400
                };
                var errorStream = new System.IO.MemoryStream();
                serializer.Serialize(errorResult, errorStream);
                errorStream.Position = 0;
                return errorStream;
            }

            var httpResults = await customizeResponseExamples.NotFoundResponseWithHeaderV1Async(x, __context__);
            HttpResultSerializationOptions.ProtocolFormat serializationFormat = HttpResultSerializationOptions.ProtocolFormat.HttpApi;
            HttpResultSerializationOptions.ProtocolVersion serializationVersion = HttpResultSerializationOptions.ProtocolVersion.V1;
            var serializationOptions = new HttpResultSerializationOptions { Format = serializationFormat, Version = serializationVersion, Serializer = serializer };
            var response = httpResults.Serialize(serializationOptions);
            return response;
        }

        private static void SetExecutionEnvironment()
        {
            const string envName = "AWS_EXECUTION_ENV";

            var envValue = new StringBuilder();

            // If there is an existing execution environment variable add the annotations package as a suffix.
            if(!string.IsNullOrEmpty(Environment.GetEnvironmentVariable(envName)))
            {
                envValue.Append($"{Environment.GetEnvironmentVariable(envName)}_");
            }

            envValue.Append("lib/amazon-lambda-annotations#1.3.1.0");

            Environment.SetEnvironmentVariable(envName, envValue.ToString());
        }
    }
}