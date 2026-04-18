# Отчёт по лабораторной работе №2

## Локализация WPF-приложения

**Выполнил:** Ereb  
**Решение:** `Lab2`  
**Тема:** реализация многоязычной поддержки WPF-приложения с использованием разных подходов к локализации

---

## 1. Введение

### 1.1. Цель работы

Целью лабораторной работы является изучение и практическая реализация локализации WPF-приложения тремя разными способами. В качестве основы использовано приложение из предыдущей лабораторной работы, посвящённой привязкам данных в WPF.

В рамках данной работы в приложение была добавлена динамическая поддержка двух языков:

- русский;
- английский.

Переключение языка должно происходить без перезапуска приложения.

### 1.2. Задачи работы

Для достижения цели были поставлены следующие задачи:

1. Модифицировать приложение из лабораторной работы №1.
2. Добавить поддержку двух языков интерфейса: русского и английского.
3. Реализовать динамическое переключение языка во время работы программы.
4. Перевести статические элементы интерфейса и текстовые сообщения.
5. Выполнить локализацию тремя различными способами:
   - через `RESX`;
   - через `XAML ResourceDictionary`;
   - через внешнюю библиотеку классов.
6. Сравнить полученные подходы и определить, в каких случаях каждый из них удобнее использовать.

---

## 2. Теоретические сведения

### 2.1. Локализация через RESX

`RESX` — это стандартный механизм платформы .NET для хранения ресурсов приложения. Обычно в таких файлах хранятся строки, изображения, иконки и другие локализуемые данные.

Для каждого языка создаётся отдельный ресурсный файл. Например:

- `Strings.resx` — базовый набор ресурсов;
- `Strings.ru.resx` — русский перевод.

Доступ к строкам выполняется через `ResourceManager`, который выбирает нужное значение по имени ключа и текущей культуре.

#### Преимущества

- стандартный способ локализации в .NET;
- хорошо подходит для крупных приложений;
- удобно масштабируется при добавлении новых языков.

#### Недостатки

- в WPF требует дополнительной логики для обновления интерфейса на лету;
- часть работы приходится делать вручную через сервис локализации и уведомления об изменении свойств.

### 2.2. Локализация через XAML ResourceDictionary

В данном подходе переводы хранятся в XAML-словарях ресурсов. Для каждого языка создаётся отдельный файл словаря, например:

- `Strings.ru.xaml`;
- `Strings.en.xaml`.

Строки описываются как ресурсы с ключами, а в интерфейсе подставляются через `DynamicResource`.

Пример:

```xml
<TextBlock Text="{DynamicResource WindowTitle}" />
```

При смене языка приложение заменяет один словарь ресурсов на другой, после чего интерфейс автоматически обновляется.

#### Преимущества

- естественная интеграция с WPF;
- удобно использовать прямо в XAML;
- хорошо сочетается со стилями и шаблонами.

#### Недостатки

- нет типобезопасности;
- ключи являются строками, поэтому ошибка в названии ключа обнаруживается только во время выполнения.

### 2.3. Локализация через внешнюю библиотеку классов

В этом варианте переводы вынесены в отдельную библиотеку классов. В библиотеке объявляется интерфейс с набором строк, а для каждого языка создаётся отдельная реализация.

Принцип работы:

- интерфейс `IStrings` задаёт набор всех текстов приложения;
- `StringsRu` содержит русские строки;
- `StringsEn` содержит английские строки;
- `LocalizationService` переключает текущую реализацию.

Такой подход делает локализацию независимой от конкретного WPF-приложения и позволяет переиспользовать библиотеку в других проектах.

#### Преимущества

- высокая типобезопасность;
- хорошая архитектурная изоляция;
- удобное переиспользование;
- хорошо показывает применение ООП.

#### Недостатки

- самый большой объём кода;
- при добавлении новых строк нужно менять интерфейс и все языковые реализации.

---

## 3. Структура решения

В решении используются четыре проекта.

### 3.1. `WpfLocalizationResx`

Это WPF-приложение, в котором локализация реализована через `RESX`.

Основные файлы:

- `WpfLocalizationResx/Resources/Strings.resx`
- `WpfLocalizationResx/Resources/Strings.ru.resx`
- `WpfLocalizationResx/Services/LocalizationService.cs`
- `WpfLocalizationResx/MainWindow.xaml`
- `WpfLocalizationResx/Views/Tabs/*.xaml`

### 3.2. `WpfLocalizationResourceDictionary`

Это WPF-приложение, где локализация сделана через XAML-словари ресурсов.

Основные файлы:

- `WpfLocalizationResourceDictionary/Resources/Strings.ru.xaml`
- `WpfLocalizationResourceDictionary/Resources/Strings.en.xaml`
- `WpfLocalizationResourceDictionary/App.xaml`
- `WpfLocalizationResourceDictionary/Services/LocalizationService.cs`
- `WpfLocalizationResourceDictionary/MainWindow.xaml`
- `WpfLocalizationResourceDictionary/Views/Tabs/*.xaml`

### 3.3. `LocalizationLibrary`

Это библиотека классов, содержащая переводы и сервис локализации для варианта с внешней библиотекой.

Основные файлы:

- `WpfLocalizationExternalLibrary/LocalizationLibrary/IStrings.cs`
- `WpfLocalizationExternalLibrary/LocalizationLibrary/StringsRu.cs`
- `WpfLocalizationExternalLibrary/LocalizationLibrary/StringsEn.cs`
- `WpfLocalizationExternalLibrary/LocalizationLibrary/LocalizationService.cs`

### 3.4. `WpfApp`

Это WPF-приложение, которое использует проект `LocalizationLibrary`.

Основные файлы:

- `WpfLocalizationExternalLibrary/WpfApp/MainWindow.xaml`
- `WpfLocalizationExternalLibrary/WpfApp/ViewModels/AllViewModels.cs`
- `WpfLocalizationExternalLibrary/WpfApp/Views/Tabs/*.xaml`

---

## 4. Реализация локализации через RESX

### 4.1. Общая идея

Вариант с `RESX` реализован в проекте `WpfLocalizationResx`. Переводы хранятся в ресурсных файлах, а доступ к ним выполняется через `ResourceManager`.

### 4.2. Где находятся переводы

Файлы ресурсов:

- `WpfLocalizationResx/Resources/Strings.resx`
- `WpfLocalizationResx/Resources/Strings.ru.resx`

В них находятся ключи, соответствующие всем строкам интерфейса:

- заголовок окна;
- названия вкладок;
- подписи к полям;
- кнопки;
- описания вкладок;
- строки состояний;
- пункты `ComboBox`.

### 4.3. Где находится логика переключения языка

Сервис локализации:

- `WpfLocalizationResx/Services/LocalizationService.cs`

Он:

1. создаёт `ResourceManager`;
2. хранит текущую культуру;
3. возвращает значения строк через свойства;
4. при смене языка вызывает `OnPropertyChanged("")`.

Пример идеи:

```csharp
public void SetLanguage(string languageCode)
{
    _culture = new CultureInfo(languageCode);
    CultureInfo.CurrentUICulture = _culture;
    CultureInfo.DefaultThreadCurrentUICulture = _culture;
    OnPropertyChanged("");
}
```

### 4.4. Как строки попадают в интерфейс

Во `ViewModel` есть доступ к сервису локализации:

```csharp
public LocalizationService Localization => LocalizationService.Instance;
```

В XAML используются привязки вида:

```xml
Text="{Binding Localization.DefaultBindingTitle}"
```

или

```xml
Content="{Binding Localization.ResetAll}"
```

### 4.5. Особенности реализации

После доработки в проекте `WpfLocalizationResx` переводится уже весь текст приложения, а не только основные заголовки. Это делает данный проект сопоставимым по полноте локализации с двумя другими вариантами.

### 4.6. Место для скриншотов

- Скриншот 1 — `WpfLocalizationResx` на русском языке.
- Скриншот 2 — `WpfLocalizationResx` после переключения на английский язык.

---

## 5. Реализация локализации через ResourceDictionary

### 5.1. Общая идея

Вариант через словари ресурсов реализован в проекте `WpfLocalizationResourceDictionary`. Переводы находятся в отдельных XAML-файлах и подключаются как ресурсы приложения.

### 5.2. Где находятся словари

Файлы словарей:

- `WpfLocalizationResourceDictionary/Resources/Strings.ru.xaml`
- `WpfLocalizationResourceDictionary/Resources/Strings.en.xaml`

Словарь по умолчанию подключается в:

- `WpfLocalizationResourceDictionary/App.xaml`

### 5.3. Где находится логика переключения языка

Сервис локализации:

- `WpfLocalizationResourceDictionary/Services/LocalizationService.cs`

Он:

1. определяет, какой словарь сейчас подключён;
2. удаляет старый словарь;
3. подключает новый словарь по пути `Resources/Strings.{lang}.xaml`;
4. уведомляет интерфейс об обновлении.

### 5.4. Как строки попадают в интерфейс

В XAML строки подключаются через `DynamicResource`:

```xml
Text="{DynamicResource DefaultBindingTitle}"
```

Благодаря этому после замены словаря интерфейс обновляется автоматически.

### 5.5. Особенности реализации

Этот вариант наиболее естественно вписывается именно в WPF, потому что словари ресурсов и так являются базовой частью механизма оформления приложения.

### 5.6. Место для скриншотов

- Скриншот 3 — `WpfLocalizationResourceDictionary` на русском языке.
- Скриншот 4 — `WpfLocalizationResourceDictionary` после переключения на английский язык.

---

## 6. Реализация локализации через внешнюю библиотеку

### 6.1. Общая идея

Этот вариант разделён на два проекта:

- `LocalizationLibrary` — библиотека переводов;
- `WpfApp` — приложение, использующее эту библиотеку.

### 6.2. Где находятся переводы

Интерфейс со строками:

- `WpfLocalizationExternalLibrary/LocalizationLibrary/IStrings.cs`

Реализации переводов:

- `WpfLocalizationExternalLibrary/LocalizationLibrary/StringsRu.cs`
- `WpfLocalizationExternalLibrary/LocalizationLibrary/StringsEn.cs`

### 6.3. Где находится логика переключения языка

Сервис локализации:

- `WpfLocalizationExternalLibrary/LocalizationLibrary/LocalizationService.cs`

Он хранит текущий объект с переводами и при смене языка заменяет его:

```csharp
_strings = languageCode switch
{
    "en" => new StringsEn(),
    "ru" => new StringsRu(),
    _ => new StringsRu()
};
```

### 6.4. Как строки попадают в интерфейс

Во `WpfApp` интерфейс работает с библиотекой через сервис локализации:

```xml
Text="{Binding Localization.WindowTitle}"
```

или

```xml
Text="{Binding Localization.Trigger1}"
```

### 6.5. Особенности реализации

Это самый архитектурно чистый вариант:

- переводы изолированы в отдельном проекте;
- код WPF-приложения не зависит от внутреннего хранения строк;
- решение хорошо показывает использование интерфейсов, инкапсуляции и полиморфизма.

### 6.6. Место для скриншотов

- Скриншот 5 — `WpfApp` на русском языке.
- Скриншот 6 — `WpfApp` после переключения на английский язык.

---

## 7. Общий механизм переключения языка

Во всех трёх вариантах логика переключения языка устроена одинаково.

В `MainWindow.xaml` находится `ComboBox` выбора языка. При изменении выбранного элемента вызывается обработчик, который передаёт код языка в `LocalizationService`.

Общая идея обработчика:

```csharp
private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    if (sender is ComboBox combo && combo.SelectedItem is ComboBoxItem item && item.Tag is string langCode)
    {
        LocalizationService.Instance.SetLanguage(langCode);
    }
}
```

После этого сервис локализации меняет источник переводов и уведомляет интерфейс через `INotifyPropertyChanged`.

---

## 8. Соблюдение MVVM

По условию задания необходимо соблюдать паттерн MVVM. В решении это выполнено следующим образом:

- `View` описывает интерфейс в XAML;
- `ViewModel` хранит состояние и команды;
- сервис локализации передаёт переведённые строки в `ViewModel`;
- `ViewModel` подписывается на событие `PropertyChanged` сервиса локализации;
- интерфейс получает обновлённые строки через привязки.

Пример:

```csharp
public MainViewModel()
{
    LocalizationService.Instance.PropertyChanged += (s, e) =>
    {
        OnPropertyChanged("");
    };
}
```

Таким образом, локализация встроена в MVVM-архитектуру корректно.

---

## 9. Сравнение реализованных подходов

| Критерий | RESX | ResourceDictionary | Внешняя библиотека |
|---|---|---|---|
| Где хранятся переводы | `.resx` | `.xaml` | `.cs` |
| Основной механизм | `ResourceManager` | `DynamicResource` + словари | интерфейс + классы |
| Интеграция с WPF | средняя | высокая | высокая |
| Типобезопасность | средняя | низкая | высокая |
| Переиспользование | среднее | низкое | высокое |
| Удобство для WPF UI | среднее | высокое | высокое |
| Объём кода | средний | средний | наибольший |

### Вывод по сравнению

- `RESX` — стандартный для .NET способ локализации;
- `ResourceDictionary` — самый естественный для WPF;
- внешняя библиотека — самый гибкий и архитектурно выразительный вариант.

---

## 10. Ссылка на проект

Удалённый репозиторий проекта:

`https://github.com/stitch2277-bit/OOP_Lab_1.git`

Основная локальная ветка:

`main`

---

## 11. Заключение

В ходе выполнения лабораторной работы были изучены и реализованы три способа локализации WPF-приложения:

1. через `RESX`;
2. через `XAML ResourceDictionary`;
3. через внешнюю библиотеку классов.

Во всех вариантах выполнено динамическое переключение между русским и английским языками без перезапуска приложения. Также был сохранён паттерн MVVM.

В результате работы удалось не только реализовать поддержку двух языков, но и сравнить три различных механизма локализации с точки зрения архитектуры, удобства использования и применимости в WPF-приложениях.

Практический вывод:

- для стандартных .NET-проектов удобен `RESX`;
- для WPF-интерфейсов особенно удобен `ResourceDictionary`;
- для переиспользуемой и строгой архитектуры лучше подходит внешняя библиотека.

Все поставленные задачи лабораторной работы выполнены.

---

## Приложение А. Ключевые файлы решения

### RESX-вариант

- `WpfLocalizationResx/Resources/Strings.resx`
- `WpfLocalizationResx/Resources/Strings.ru.resx`
- `WpfLocalizationResx/Services/LocalizationService.cs`

### ResourceDictionary-вариант

- `WpfLocalizationResourceDictionary/Resources/Strings.ru.xaml`
- `WpfLocalizationResourceDictionary/Resources/Strings.en.xaml`
- `WpfLocalizationResourceDictionary/Services/LocalizationService.cs`
- `WpfLocalizationResourceDictionary/App.xaml`

### Внешняя библиотека

- `WpfLocalizationExternalLibrary/LocalizationLibrary/IStrings.cs`
- `WpfLocalizationExternalLibrary/LocalizationLibrary/StringsRu.cs`
- `WpfLocalizationExternalLibrary/LocalizationLibrary/StringsEn.cs`
- `WpfLocalizationExternalLibrary/LocalizationLibrary/LocalizationService.cs`
- `WpfLocalizationExternalLibrary/WpfApp/MainWindow.xaml`
