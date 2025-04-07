namespace Restaurants.API
{
    //serlog using
    //1- log level override => to override the log level for specific namespaces or categories 
    //example: Microsoft and Microsoft.EntityFrameworkCore 
    //2-formatting the output => to format the output of the logs 
    //example: {Timestamp:dd-MM HH:mm:ss} {Level:u3} | {SourceContext}| {NewLine} {Message:lj} {NewLine} {Exception}
    //like that we can buid an template log for our selves  
    //3-enrichers => to add additional information to the logs
    //example: {SourceContext} => to add the source context of the log
    //4- sinks => to specify where the logs should be written
    //example: WriteTo.Console => to write the logs to the console
}
