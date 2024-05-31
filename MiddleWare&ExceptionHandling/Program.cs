using MiddleWare_ExceptionHandling;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
  // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<AppExceptionHandler>();

var app = builder.Build();


/*Middelware 
 * This is a component which is inbetween webserver and client applicaion
 * It manage and modify all the incomming request and outgoing responses
 * we can also create our custom middle ware for various tasl like logging, authentication, authorization, error handling 
 */

//Here we inilized our custom middle ware
/*app.Run( (contest) =>
{
    return contest.Response.WriteAsync("Hello");
});
*/
//Here again we are setting our second middle ware
/*app.Run((contest) =>
{
    return contest.Response.WriteAsync("middle ware 2");
});*/
//The Above middle ware did not responce because Only one Run method can be inialized in a program
//Thats why we always use "Use" method for multiple custom middle ware
/*app.Use(async (contest, next) =>
{
    await contest.Response.WriteAsync("Hello");
    await next(contest);
});

//Here again we are setting our second middle ware
app.Use(async (contest, next) =>
{
    await contest.Response.WriteAsync("middle ware 2");
    await next(contest);
});//Now both custom middleware are running running 
*/



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//builtin middle wares
//Here we are adding ExceptionHandler Middle ware
app.UseExceptionHandler(_ => { });


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
