# Repositório do Desafio da Digital Pages

- A Versão Android ainda não está finalizada devido a um bug no mono 4.8.* (ainda em desenvolvimento) que não está efetuando o link das libs Android.
- Sem suporte para dados offline.

# Libs Usadas

- Retrofit (Java) -> http://square.github.io/retrofit/
- AFNetworking (Objective-C) -> https://github.com/AFNetworking/AFNetworking
- Acr.Dialogs (C#) -> https://github.com/aritchie/acr-xamarin-forms
- XamarinForms (C#) -> http://www.xamarin.com/forms
- Prism (C#) -> https://github.com/PrismLibrary/
- NewtonSoft (C#) -> https://github.com/JamesNK/Newtonsoft.Json

# Todo List

- Salvar os dados da API no SQLite e retornar o callback para o aplicativo ao invés de retornar diretamente o Json, isso reduz as chamadas a API que são limitadas e aumenta a performance.
- Implementar testes ao invés de criar uma aplicação em Java/Objective-C para testar os dados.
- Melhorar o Makefile adicionando build da lib do android
- Layout.

