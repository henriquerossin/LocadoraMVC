using Locadora.View.Menus;

MenuPrincipal menuPrincipal = new();

try 
{ 
    menuPrincipal.Run(); 
}
catch (Exception e) 
{ 
    Console.WriteLine(e); 
}