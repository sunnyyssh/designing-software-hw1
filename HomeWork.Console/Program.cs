using HomeWork.Domain;
using HomeWork.Application;
using HomeWork.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Sunnyyssh.ConsoleUI;
using Sunnyyssh.ConsoleUI.Binding;
using System.Collections.Immutable;
using HomeWork.Application.Services;
using Microsoft.VisualBasic;

var services = new ServiceCollection()
    .AddDomain()
    .AddApplication()
    .AddInfrastucture()
    .BuildServiceProvider();

// CAUTION
// CAUTION
// CAUTION
//
// The whole UI configuration below is absolute cringe.
// Do not read it if you don't wanna be upset.
//
// CAUTION
// CAUTION
// CAUTION

var appSettings = new ApplicationSettings();
var appBuilder = new ApplicationBuilder(appSettings);

var infoBlock = new TextBlockBuilder(1.0, 2)
{
    WordWrap = true,
    TextHorizontalAligning = HorizontalAligning.Center,
    StartingText = "Use <TAB> to switch focus, <ENTER> to enter value, ARROWS to move inside one UI element. "
        + "Enter info and then press \"ADD\" button"
};
appBuilder.Add(infoBlock, 0, 0);

var errorBlock = new TextBlockBuilder(1.0, 2)
{
    WordWrap = true,
    TextHorizontalAligning = HorizontalAligning.Center,
    Foreground = Color.DarkRed,
};
appBuilder.Add(errorBlock, 0, 2, out var builtErrorBlock);

var foodBoxInfoBlock = new TextBlockBuilder(0.2, 1)
{
    StartingText = "Food (INT)"
};
appBuilder.Add(foodBoxInfoBlock, 0, 4);

var kindnessBoxInfoBlock = new TextBlockBuilder(0.2, 1)
{
    StartingText = "Kindness (INT)"
};
appBuilder.Add(kindnessBoxInfoBlock, 0.2, 4);

var dateOfBirthBoxInfoBlock = new TextBlockBuilder(0.2, 1)
{
    StartingText = "Date of birth (DD.MM.YYYY)"
};
appBuilder.Add(dateOfBirthBoxInfoBlock, 0.4, 4);

var foodBox = new TextBoxBuilder(0.2, 3) 
{ 
    NotFocusedBackground = Color.DarkGray,
    FocusedBackground = Color.Gray,
    StartingText = "10",
};
appBuilder.Add(foodBox, 0, 5, out var builtFoodBox);

var kindnessBox = new TextBoxBuilder(0.2, 3)
{
    NotFocusedBackground = Color.DarkGray,
    FocusedBackground = Color.Gray,
    StartingText = "5",
};
appBuilder.Add(kindnessBox, 0.2, 5, out var builtKindnessBox);

var dateOfBirthBox = new TextBoxBuilder(0.2, 3)
{
    NotFocusedBackground = Color.DarkGray,
    FocusedBackground = Color.Gray,
    StartingText = "12.10.2005",
    BorderKind = BorderKind.DoubleLine,
};
appBuilder.Add(dateOfBirthBox, 0.4, 5, out var builtDateOfBirthBox);

var animalSwitcher = new RowTextChooserBuilder(0.2, 9, Orientation.Vertical,
    ["rabbit", "monkey", "wolf", "tiger"])
{
    BorderKind = BorderKind.DoubleLine,
};
appBuilder.Add(animalSwitcher, 0.6, 5, out var builtAnimalSwitcher);

var enterButton = new ButtonBuilder(0.2, 5)
{
    Text = "ADD",
    NotFocusedBackground = Color.DarkGreen,
    FocusedBackground = Color.Green,
};
appBuilder.Add(enterButton, 0.8, 5, out var builtEnterButton);

var foodSumInfoBlock = new TextBlockBuilder(0.2, 1)
{
    StartingText = "Food sum:"
};
appBuilder.Add(foodSumInfoBlock, 0, 8);

var foodSumBlock = new TextBlockBuilder(0.2, 2)
{
    Background = Color.DarkBlue,
};
appBuilder.Add(foodSumBlock, 0, 9, out var builtFoodSumInfoBlock);

var tableHeaders = new string[] { "Playble animals" }.ToImmutableList();
var grid = new GridDefinition(GridRowDefinition.From(0.1, 0.1, 0.1, 0.1, 0.1), GridColumnDefinition.From(1.0));
var playableTable = new ViewTableBuilder(0.4, 15, tableHeaders, grid, 100)
{
    UserEditable = false,
};
appBuilder.Add(playableTable, 0.2, 8, out var builtPlayableTable);

var app = appBuilder.Build();

var errorText = new ObservableObject<string?>(null);
builtErrorBlock.Element!.Observe(errorText);

var table = new BindableDataTable<string?>(100, 1, null);
builtPlayableTable.Element!.Observe(table);

var foodText = new BindableObject<string?>(null);
builtFoodBox.Element!.Bind(foodText);

var kindnessText = new BindableObject<string?>(null);
builtKindnessBox.Element!.Bind(kindnessText);

var dateOfBirthText = new BindableObject<string?>(null);
builtDateOfBirthBox.Element!.Bind(dateOfBirthText);

var foodSumInfoText = new ObservableObject<string?>("0"); 
builtFoodSumInfoBlock.Element!.Observe(foodSumInfoText);

string chosen = "wolf";
builtAnimalSwitcher.Element!.ChosenOn += (chooser, args) => chosen = ((TextOptionElement)args.OptionElement).Text;

builtEnterButton.Element!.Pressed += (button, args) => 
{
    if (!int.TryParse(foodText.Value, out int food))
    {
        errorText.Value = "Cannot parse food value";
        return;
    }
    if (!int.TryParse(kindnessText.Value, out var kindness))
    {
        errorText.Value = "Cannot parse kindness value";
    }
    if (!DateOnly.TryParse(dateOfBirthText.Value, out DateOnly dateOfBirth))
    {
        errorText.Value = "Cannot parse date of birth value";
    }
    switch (chosen)
    {
        case "rabbit":
            var addRabbit = services.GetRequiredService<IAddRabbitService>();
            var rabbitRes = addRabbit.AddRabbit(food, kindness, dateOfBirth);
            errorText.Value = string.Join("; ", rabbitRes.ValidationErrors.Select(x => x.Message));
            break;
        case "monkey":
            var addMonkey = services.GetRequiredService<IAddMonkeyService>();
            var monkeyRes = addMonkey.AddMonkey(food, kindness, dateOfBirth);
            errorText.Value = string.Join("; ", monkeyRes.ValidationErrors.Select(x => x.Message));
            break;
        case "wolf":
            var addWolf = services.GetRequiredService<IAddWolfService>();
            var wolfRes = addWolf.AddWolf(food, dateOfBirth);
            errorText.Value = string.Join("; ", wolfRes.ValidationErrors.Select(x => x.Message));
            break;
        case "tiger":
            var addTiger = services.GetRequiredService<IAddTigerService>();
            var tigerRes = addTiger.AddTiger(food, dateOfBirth);
            errorText.Value = string.Join("; ", tigerRes.ValidationErrors.Select(x => x.Message));
            break;
    }
    foodSumInfoText.Value = services
        .GetRequiredService<ICountAllFoodService>()
        .CountAllFood() is { IsSuccess: true, Value: {} val } ? val.ToString() : "error";
    var touchable = services
        .GetRequiredService<IGetAllTouchableService>()
        .GetAllTouchable() is { IsSuccess: true, Value: {} animals }
            ? animals.Select(a => a.ToString()).ToArray()
            : ["error"];
    for (int i = 0; i < touchable.Length; i++)
    {
        table[i, 0] = touchable[i];
    }
};

app.Run();