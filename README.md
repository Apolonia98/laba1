# Лаб 1. Реалізація Абстрактної фабрики

Виконав: Хмелівський Станіслав, варіант 27: абстрактна фабрика столів.

Рішення `AbstractFactoryTables.sln` складається з двох проєктів:

* `TablesFactoryLibrary` (бібліотека класів, збирається в `TablesFactoryLibrary.dll`) містить класи патерну:
  * абстрактні продукти `DiningTable` (обідній стіл), `Desk` (письмовий стіл), `CoffeeTable` (журнальний столик);
  * абстрактна фабрика `TableFactory` з методами `createDiningTable()`, `createDesk()`, `createCoffeeTable()` і `MakeSet()`;
  * конкретні фабрики `WoodTableFactory` (дерев'яні столи) і `GlassTableFactory` (скляні столи) зі своїми продуктами.
* `AbstractFactoryTables` (Windows Forms) підключає `TablesFactoryLibrary.dll`. Кнопки «Дерев'яні столи» і «Скляні столи» вибирають фабрику, і форма показує набір із трьох столів, їх ціни, загальну суму і малюнок.

Діаграма класів: `diagram.png`. Скріншоти: `screen_wood.png`, `screen_glass.png`.

Запуск: відкрити `AbstractFactoryTables.sln` у Visual Studio і натиснути F5.
