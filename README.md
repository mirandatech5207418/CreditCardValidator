# 💳 Validador de Cartão de Crédito em C#

> Identifica bandeiras e valida números de cartão usando o algoritmo Luhn.

---

## 🎯 Objetivos de Aprendizagem

- 📌 Reproduzir e melhorar um projeto existente
- ⚙️ Aplicar conceitos de C# (strings, parsing, loops)
- 📝 Documentar o projeto com README
- 🔀 Usar Git para versionamento

---

## 🚀 Como Executar

1. Instale o [.NET SDK](https://dotnet.microsoft.com)
2. Clone o repositório: `git clone <seu-repo>`
3. No diretório do projeto: `dotnet run`
4. Digite o número do cartão quando solicitado

---

## 🧪 Exemplos de Teste

| Bandeira      | Número               | Status        |
|---------------|----------------------|---------------|
| 💙 Visa       | `4111111111111111`   | ✅ Válido     |
| 🔴 MasterCard | `5555555555554444`   | ✅ Válido     |
| 🟡 Elo        | `5067270000000000`   | ✅ Válido     |
| ⚪ Inválido   | `1234567890123456`   | ❌ Inválido   |

---

## 🏗️ Decisões Técnicas

- 🔍 **Identificação de Bandeira** — Baseada em prefixos (ex: Visa inicia com `4`). Para Elo, incluídos prefixes comuns de pesquisas públicas para maior precisão.
- 🔢 **Validação Luhn** — Algoritmo padrão da indústria para checksum de cartões.
- 📐 **Comprimento por Bandeira** — Padrões globais verificados individualmente.
- ⚠️ **Tratamento de Erros** — Entradas não numéricas são rejeitadas com mensagem amigável.
- 🏦 **Bandeiras suportadas** — Visa, MasterCard, Elo, American Express, Discover, Hipercard.

---

## 📚 Recursos Usados

- 📖 [Documentação .NET](https://docs.microsoft.com/dotnet)
- 📄 [GitHub Markdown](https://github.com/adam-p/markdown-here)
- 🤖 GitHub Copilot — sugestões de código durante o desenvolvimento

---

## 🖼️ Imagens

Pasta `/images` (opcional): adicione capturas de tela do console em execução.
