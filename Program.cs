using ConsoleMenuCreation;

// Criando cada menu separadamente e passando o título daquele menu
// É bom definir todos os menus antes de adicionar as opções, você pode ter problemas de compilação se fizer de outro jeito
Menu menu_principal = new Menu("Menu Principal");
Menu menu_nomes = new Menu("Menu de nomes");
Menu menu_numeros = new Menu("Menu de numeros");

// Adicionando cada opção pros menus
// MenuOption pode ser selecionado e quando clica enter ele executa algo
// OptionLabel NÃO pode ser selecionado, aparecerá apenas como texto
// No primeiro campo de MenuOption deve-se passar uma Action, que recebe um delegate ou uma assinatura de um método (nome do método sem parenteses ())
menu_principal.AddOption(new MenuOption(MenuDeNomes, "Menu de nomes", ConsoleColor.Magenta));
menu_principal.AddOption(new MenuOption(MenuDeNumeros, "Menu de numeros", ConsoleColor.Magenta));
menu_principal.AddOption(new MenuOption(null, "Essa opção pode ser selecionada, mas não vai acontecer nada, pois a ação é nula", ConsoleColor.Magenta));
menu_principal.AddOption(new OptionLabel("Essa opção é um OptionLabel, não tem como selecionar", ConsoleColor.Magenta));
menu_principal.AddOption(new MenuOption(Exit, "Sair", ConsoleColor.Magenta));

menu_nomes.AddOption(new OptionLabel("Jaum", ConsoleColor.Yellow));
menu_nomes.AddOption(new OptionLabel("Daniel", ConsoleColor.Magenta));
menu_nomes.AddOption(new OptionLabel("Náthan", ConsoleColor.Cyan));
menu_nomes.AddOption(new OptionLabel("Humberto", ConsoleColor.Red));
menu_nomes.AddOption(new OptionLabel("Mauricio", ConsoleColor.White));
menu_nomes.AddOption(new MenuOption(MenuPrincipal, "Voltar para o menu inicial", ConsoleColor.Magenta));

menu_numeros.AddOption(new OptionLabel("13", ConsoleColor.Yellow));
menu_numeros.AddOption(new OptionLabel("45", ConsoleColor.Magenta));
menu_numeros.AddOption(new OptionLabel("123", ConsoleColor.Cyan));
menu_numeros.AddOption(new OptionLabel("6", ConsoleColor.Red));
menu_numeros.AddOption(new OptionLabel("90", ConsoleColor.White));
menu_numeros.AddOption(new MenuOption(MenuPrincipal, "Voltar para o menu inicial", ConsoleColor.Blue));

// Metodos que vao ser chamados quando as opções forem escolhidas
void MenuPrincipal()
{
    menu_principal.ShowMenu();
}
void MenuDeNomes()
{
    menu_nomes.ShowMenu();
}
void MenuDeNumeros()
{
    menu_numeros.ShowMenu();
}
void Exit()
{
    Environment.Exit(69);
}

//Da inicio a execução do codigo
MenuPrincipal();