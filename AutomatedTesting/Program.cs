using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


IWebDriver driver = new ChromeDriver();

driver.Navigate().GoToUrl(url: "http://svyatoslav.biz/testlab/wt/");

Console.ForegroundColor = ConsoleColor.Magenta;

Console.WriteLine();
Console.WriteLine("1 - Проверка наличия слов \"menu\" и \"banners\" на главной странице");
bool containsMenu = driver.PageSource.Contains("menu");
bool containsBanners = driver.PageSource.Contains("banners");
Console.WriteLine("Содержит слово \"menu\": " + containsMenu);
Console.WriteLine("Содержит слово \"banners\": " + containsBanners);

Console.WriteLine();
Console.WriteLine("2 - Поиск нижней ячейки таблицы и проверка наличия текста \"CoolSoft by Somebody\"");
string pageSource = driver.PageSource;
string searchText = "© CoolSoft by Somebody";
bool isTextPresent = pageSource.Contains(searchText);
Console.WriteLine("Нижняя ячейка содержит текст \"CoolSoft by Somebody\": " + isTextPresent);
Console.WriteLine();

Console.WriteLine("3 - Проверка значений полей формы по умолчанию");
IWebElement heightField = driver.FindElement(By.Name("height"));
IWebElement weightField = driver.FindElement(By.Name("weight"));
IWebElement genderField = driver.FindElement(By.Name("gender"));
bool isHeightEmpty = string.IsNullOrEmpty(heightField.GetAttribute("value"));
bool isWeightEmpty = string.IsNullOrEmpty(weightField.GetAttribute("value"));
bool isGenderNotSelected = !genderField.Selected;
Console.WriteLine("Поле \"Рост\" пустое: " + isHeightEmpty);
Console.WriteLine("Поле \"Вес\" пустое: " + isWeightEmpty);
Console.WriteLine("Поле \"Пол\" не выбрано: " + isGenderNotSelected);
Console.WriteLine();

Console.WriteLine("4 - Проверка исчезновения формы и появления надписи");
heightField.SendKeys("50");
weightField.SendKeys("3");
IWebElement submitButton = driver.FindElement(By.XPath("//input[@type='submit']"));
submitButton.Click();
bool isMessageDisplayed = driver.PageSource.Contains("Слишком большая масса тела");

bool formDisappears = !driver.FindElement(By.TagName("form")).Displayed;
Console.WriteLine("Форма исчезает: " + formDisappears);
Console.WriteLine("Надпись отображается: " + isMessageDisplayed);
Console.WriteLine();

Console.WriteLine("5 - Проверка содержания главной страницы после открытия");
driver.Navigate().Back();
bool containsForm = driver.FindElement(By.TagName("form")).Displayed;
bool containsTextFields = driver.FindElements(By.XPath("//input[@type='text']")).Count == 3;
bool containsRadioButtons = driver.FindElements(By.XPath("//input[@type='radio']")).Count == 2;
bool containsButton = driver.FindElement(By.XPath("//input[@type='submit']")).Displayed;
Console.WriteLine("Содержит форму: " + containsForm);
Console.WriteLine("Содержит 3 текстовых поля: " + containsTextFields);
Console.WriteLine("Содержит 2 радио-кнопки: " + containsRadioButtons);
Console.WriteLine("Содержит кнопку: " + containsButton);
Console.WriteLine();

Console.WriteLine("6 - Проверка наличия сообщений при неверном вводе веса и роста");
heightField.Clear();
heightField.SendKeys("1000");
weightField.Clear();
weightField.SendKeys("1000");
submitButton.Click();
bool containsHeightErrorMessage = driver.PageSource.Contains("Рост должен быть в диапазоне 50-300 см.");
bool containsWeightErrorMessage = driver.PageSource.Contains("Вес должен быть в диапазоне 3-500 кг.");
Console.WriteLine("Содержит сообщение об ошибке для роста: " + containsHeightErrorMessage);
Console.WriteLine("Содержит сообщение об ошибке для веса: " + containsWeightErrorMessage);
Console.WriteLine();

Console.WriteLine("7 - Проверка текущей даты на главной странице");
string currentDate = DateTime.Now.ToString("dd.MM.yyyy");
bool containsCurrentDate = driver.PageSource.Contains(currentDate);
Console.WriteLine("Содержит текущую дату (" + currentDate + "): " + containsCurrentDate);
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.White;

driver.Quit();


