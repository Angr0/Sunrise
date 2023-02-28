using Microsoft.EntityFrameworkCore;
using Sunrise;
using Sunrise.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.MapGet("/room", async (DataContext context) => 
    await context.Rooms.ToListAsync());


app.MapGet("/room/{id}", async (DataContext context, int id) =>
    await context.Rooms.FindAsync(id) is Room room ? Results.Ok(room) : Results.NotFound("room not found"));

app.MapPost("/room", async (DataContext context, Room room) =>
{
    context.Rooms.Add(room);
    await context.SaveChangesAsync();
    return Results.Ok(await context.Rooms.ToListAsync());
});

app.MapPut("/room/{id}", async (DataContext context, Room updatedroom, int id) =>
{
    var room = await context.Rooms.FindAsync(id);
    if (room is null)
        return Results.NotFound("nie znaleziono tego pokoju");

    room.Name = updatedroom.Name;
    room.MaxAmountOfPeople = updatedroom.MaxAmountOfPeople;
    room.SingleBeds = updatedroom.SingleBeds;
    room.DoubleBeds = updatedroom.DoubleBeds;
    room.Restroom = updatedroom.Restroom;
    room.PricePerNight = updatedroom.PricePerNight;
    room.PhotosFolder = updatedroom.PhotosFolder;
    await context.SaveChangesAsync();

    return Results.Ok(await context.Rooms.ToListAsync());
});

app.MapDelete("/room/{id}", async (DataContext context, int id) =>
{
    var room = await context.Rooms.FindAsync(id);
    if (room is null)
        return Results.NotFound("nie znaleziono tego pokoju");

    context.Rooms.Remove(room);
    await context.SaveChangesAsync();

    return Results.Ok(await context.Rooms.ToListAsync());
});





app.MapGet("/opinion", async (DataContext context) =>
    await context.Opinions.ToListAsync());


app.MapGet("/opinion/{id}", async (DataContext context, int id) =>
    await context.Opinions.FindAsync(id) is Opinion opinion ? Results.Ok(opinion) : Results.NotFound("opinion not found"));

app.MapPost("/opinion", async (DataContext context, Opinion opinion) =>
{
    context.Opinions.Add(opinion);
    await context.SaveChangesAsync();
    return Results.Ok(await context.Opinions.ToListAsync());
});

app.MapPut("/opinion/{id}", async (DataContext context, Opinion updatedopinion, int id) =>
{
    var opinion = await context.Opinions.FindAsync(id);
    if (opinion is null)
        return Results.NotFound("nie znaleziono tej opinii");

    opinion.AmountOfStars = updatedopinion.AmountOfStars;
    opinion.UserIndex = updatedopinion.UserIndex;
    opinion.OpinionText = updatedopinion.OpinionText;
    await context.SaveChangesAsync();

    return Results.Ok(await context.Opinions.ToListAsync());
});

app.MapDelete("/opinion/{id}", async (DataContext context, int id) =>
{
    var opinion = await context.Opinions.FindAsync(id);
    if (opinion is null)
        return Results.NotFound("nie znaleziono tej opinii");

    context.Opinions.Remove(opinion);
    await context.SaveChangesAsync();

    return Results.Ok(await context.Opinions.ToListAsync());
});





app.MapGet("/addition", async (DataContext context) =>
    await context.Additions.ToListAsync());


app.MapGet("/addition/{id}", async (DataContext context, int id) =>
    await context.Additions.FindAsync(id) is Addition addition ? Results.Ok(addition) : Results.NotFound("addition not found"));

app.MapPost("/addition", async (DataContext context, Addition addition) =>
{
    context.Additions.Add(addition);
    await context.SaveChangesAsync();
    return Results.Ok(await context.Additions.ToListAsync());
});

app.MapPut("/addition/{id}", async (DataContext context, Addition updatedaddition, int id) =>
{
    var addition = await context.Additions.FindAsync(id);
    if (addition is null)
        return Results.NotFound("nie znaleziono tego dodatku");

    addition.Name = updatedaddition.Name;
    addition.ExtrasPrice = updatedaddition.ExtrasPrice;
    await context.SaveChangesAsync();

    return Results.Ok(await context.Additions.ToListAsync());
});

app.MapDelete("/addition/{id}", async (DataContext context, int id) =>
{
    var addition = await context.Additions.FindAsync(id);
    if (addition is null)
        return Results.NotFound("nie znaleziono tego dodatku");

    context.Additions.Remove(addition);
    await context.SaveChangesAsync();

    return Results.Ok(await context.Additions.ToListAsync());
});





app.MapGet("/payment/{id}", async (DataContext context, int id) =>
    await context.Payments.FindAsync(id) is Payment payment ? Results.Ok(payment) : Results.NotFound("payment not found"));

app.MapPost("/payment", async (DataContext context, Payment payment) =>
{
    context.Payments.Add(payment);
    await context.SaveChangesAsync();
    return Results.Ok(await context.Payments.ToListAsync());
});

app.MapPut("/payment/{id}", async (DataContext context, Payment updatedpayment, int id) =>
{
    var payment = await context.Payments.FindAsync(id);
    if (payment is null)
        return Results.NotFound("nie znaleziono platnosci");

    payment.Done = updatedpayment.Done;
    await context.SaveChangesAsync();

    return Results.Ok(await context.Payments.ToListAsync());
});






app.MapGet("/booking/{id}", async (DataContext context, int id) =>
    await context.Bookings.FindAsync(id) is Booking booking ? Results.Ok(booking) : Results.NotFound("booking not found"));

app.MapPost("/booking", async (DataContext context, Booking booking) =>
{
    context.Bookings.Add(booking);
    await context.SaveChangesAsync();
    return Results.Ok(await context.Bookings.ToListAsync());
});

app.MapPut("/booking/{id}", async (DataContext context, Booking updatedbookingn, int id) =>
{
    var booking = await context.Bookings.FindAsync(id);
    if (booking is null)
        return Results.NotFound("nie znaleziono tej rezerwacji");

    booking.Sum = booking.Sum;
    booking.PaymentIndex = booking.PaymentIndex;
    booking.UserIndex = booking.UserIndex;
    booking.RoomIndex = booking.RoomIndex;
    booking.ChosenAdditionIndex = booking.ChosenAdditionIndex;
    await context.SaveChangesAsync();

    return Results.Ok(await context.Bookings.ToListAsync());
});

app.MapDelete("/booking/{id}", async (DataContext context, int id) =>
{
    var booking = await context.Bookings.FindAsync(id);
    if (booking is null)
        return Results.NotFound("nie znaleziono tej rezerwacji");

    context.Bookings.Remove(booking);
    await context.SaveChangesAsync();

    return Results.Ok(await context.Bookings.ToListAsync());
});

app.Run();