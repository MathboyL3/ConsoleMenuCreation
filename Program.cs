using ConsoleMenuCreation;

// Criando cada menu separadamente e passando o título daquele menu
Menu menu_principal = new Menu("Menu Principal");
Menu menu_teste_1 = new Menu("Menu de teste 1");
Menu menu_teste_2 = new Menu("Menu de teste 2");

// Adicionando cada opção pros menus
menu_principal.AddOption(new MenuOption(Menu1, "Menu 1", ConsoleColor.Magenta));
menu_principal.AddOption(new MenuOption(Menu2, "Menu 2", ConsoleColor.Magenta));
menu_principal.AddOption(new OptionLabel("Label", ConsoleColor.Magenta));
menu_principal.AddOption(new MenuOption(Exit, "Sair", ConsoleColor.Magenta));

menu_teste_1.AddOption(new MenuOption(MenuP, "voltar", ConsoleColor.Magenta));

menu_teste_2.AddOption(new MenuOption(MenuP, "voltar", ConsoleColor.Blue));

// Metodos que vao ser chamados quando as opções forem escolhidas
void MenuP()
{
    menu_principal.ShowMenu();
}
void Menu1()
{
    menu_teste_1.ShowMenu();
}
void Menu2()
{
    menu_teste_2.ShowMenu();
}
void Exit()
{
    Environment.Exit(69);
}

MenuP();