for /l %x in (1, 1, 100) do type in\file%x | dotnet Grammars.dll && type out\file%x