# Aplicação de Controle de Gastos Financeiros com .NET 9 e Blazor  

## Descrição do Projeto  
Esta aplicação foi desenvolvida em **.NET 9** utilizando **Blazor** para a criação de uma interface web moderna e responsiva. O objetivo é permitir aos utilizadores um controle eficiente dos seus gastos financeiros, com acesso a dashboards interativos, relatórios detalhados e suporte multilingue (Inglês, Português e Francês).  

---

## Funcionalidades Principais  

- **Gestão de Gastos e Receitas**  
  - Registo e categorização de despesas e receitas.  
  - Suporte para múltiplas contas e categorias personalizáveis.  

- **Dashboard Interativo**  
  - Visualização em tempo real dos gastos por categoria, período ou conta.  
  - Gráficos interativos para análise de tendências e distribuição de despesas.  

- **Relatórios Detalhados**  
  - Relatórios exportáveis (PDF/Excel) de despesas e receitas.  
  - Opções de filtragem por datas, categorias ou contas específicas.  

- **Suporte Multilingue**  
  - Interface disponível em **Inglês**, **Português** e **Francês**.  
  - Seleção de idioma automática ou configurável pelo utilizador.  

- **Segurança**  
  - Autenticação com **JWT**.  
  - Criptografia de dados sensíveis.  

---

## Tecnologias Utilizadas  

- **Backend**: .NET 9 com suporte para APIs RESTful.  
- **Frontend**: Blazor Server para uma experiência de utilizador dinâmica e responsiva.  
- **Base de Dados**:  
  - **SQL Server** para armazenamento de dados estruturados.  
  - **Entity Framework Core** para acesso e manipulação de dados.  
- **Localização**: Biblioteca **IStringLocalizer** para suporte multilingue.  
- **Segurança**: Implementação de autenticação e autorização baseada em **JWT**.  

---

## Estrutura do Projeto  

1. **Módulo de Autenticação**  
   - Registo, login e gestão de sessões de utilizadores.  
2. **Módulo de Contas e Categorias**  
   - Criação e configuração de contas e categorias personalizadas.  
3. **Módulo de Registo de Movimentações**  
   - Adicionar, editar e eliminar despesas e receitas.  
4. **Módulo de Dashboard**  
   - Visualização gráfica e detalhada dos dados financeiros.  
5. **Módulo de Relatórios**  
   - Geração de relatórios detalhados exportáveis.  

---

## Configuração e Deploy  

1. **Requisitos**  
   - **.NET 9 SDK**  
   - **SQL Server**  
   - Navegador moderno compatível com Blazor Server.  

2. **Configuração do Projeto**  
   - Clone o repositório:  
     ```bash
     git clone git@github.com:alexcanario/Control.git
     cd Control
     ```  
   - Configure a conexão com a base de dados no ficheiro `appsettings.json`.  

3. **Iniciar a Aplicação**  
   - Execute os comandos:  
     ```bash
     dotnet restore
     dotnet run
     ```  
   - Acesse a aplicação no navegador: `http://localhost:5000`.  

---

## Screenshots  
- **Dashboard**:  
  ![Exemplo do dashboard](https://via.placeholder.com/800x400)  

- **Relatório Detalhado**:  
  ![Exemplo de relatório](https://via.placeholder.com/800x400)  

---

## Melhorias Futuras  
- Suporte para integração com APIs bancárias para importação de transações.  
- Versão móvel otimizada para dispositivos móveis e tablets.  
- Configuração de notificações para alertar sobre gastos excessivos.  

---

## Contribuição  
Contribuições são bem-vindas! Siga as boas práticas de desenvolvimento e envie o seu PR com as melhorias ou novas funcionalidades.  

---

## Licença  
Este projeto é licenciado sob a **MIT License**. Consulte o ficheiro `LICENSE` para mais detalhes.  