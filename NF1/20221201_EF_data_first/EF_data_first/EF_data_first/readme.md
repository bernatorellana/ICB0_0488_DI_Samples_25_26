
1. Comanda per verificar si teniu les eines EF(EntityFramework:) instal·lades. En cas afirmatiu us mostrarà número de versió, altrament Error. 
```
    dotnet ef --version
```

1. Si heu d'instalar les eines de EF, cal mirar quins SDKS teniu instal·lats, per instal·lar la versió de EF compatible:
```
    dotnet --list-sdks
```

1. Comanda per instal·lar les eines de EntityFramework, adapteu el número de versió si escau:
```
    dotnet tool install --global dotnet-ef --version 9.0.11
```

1. Crear les classes del Model a partir de la base de dades (usant el driver de Pomelo), adapteu IP, usuari i nom de BD al vostre cas
```
    dotnet ef dbcontext scaffold "Server=localhost;Database=empresa;UID=root;Password=;" Pomelo.EntityFrameworkCore.MySql -o Models -c AppDbContext -f 
```
