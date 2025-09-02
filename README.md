# 🚀 MottuPatioo

API RESTful desenvolvida com ASP.NET Core para o gerenciamento dos pátios de motos da Mottu, incluindo controle de entrada, triagem, monitoramento e gestão de colaboradores.

---

## 🧾 Descrição do Projeto

A Mottu enfrenta desafios na gestão de suas motos dentro do pátio, como imprecisões na localização, atrasos e ineficiência operacional. Este sistema propõe uma solução baseada em:

- **Classificação por cores**
- **Visão computacional**
- **Monitoramento em tempo real**

O objetivo é otimizar a organização e o controle das motos.

---

## 🎯 Objetivos

- Organizar as motos por categorias de prioridade
- Reduzir atrasos no atendimento e manutenção
- Aumentar a eficiência na gestão de localização
- Disponibilizar dados em tempo real sobre status e tempo de permanência

---

## 🧩 Solução

### Classificação por Cores

Cada moto recebe um adesivo com uma cor após triagem:

| Cor     | Classificação             | Descrição                             | Tempo Limite        |
|---------|---------------------------|----------------------------------------|---------------------|
| Verde   | Pronta para uso           | Moto liberada para entrega             | Sem limite          |
| Amarelo | Reparos rápidos           | Troca de pneus, óleo, ajustes leves    | 15 minutos          |
| Vermelho| Reparos graves            | Problemas críticos (motor, elétrica)   | Variável            |
| Roxo    | Administrativos           | Pendências legais, sem placa, Detran   | Até resolução       |

### Organização do Pátio

- Dividido por áreas conforme a cor de classificação
- Motos devem ser posicionadas na área correta

### Visão Computacional & Monitoramento

- Câmeras analisam adesivos e placas
- O sistema gera alertas se:
  - Moto estiver fora da área correta
  - Permanência exceder o limite
- Leitura de placa retorna:
  - Problema reportado
  - Data de entrada
  - Status
  - Dados do veículo

---

## 🔁 Fluxo de Funcionamento

1. **Triagem**: Classificação por cor
2. **Alocação**: Moto posicionada na área correspondente
3. **Monitoramento**:
   - Validação de posição via câmera
   - Geração de alerta se necessário
4. **Consulta**:
   - Leitura de placa exibe dados completos da moto

---

## 🧪 Tecnologias Utilizadas

- ASP.NET Core 7.0
- Entity Framework Core
- Oracle Database
- Oracle.ManagedDataAccess
- Oracle.EntityFrameworkCore
- Swagger (OpenAPI)

---

## ⚙️ Funcionalidades

A API oferece CRUD completo para:

- **Motos**
- **Triagens**
- **Monitoramentos**
- **Áreas do Pátio**
- **Colaboradores**

Outras funcionalidades:
- Relacionamentos entre entidades
- Validações automáticas
- Integração com Oracle
- Interface de testes via Swagger

---

## 🔗 Endpoints

Cada entidade possui os seguintes endpoints:

- `GET /[entidade]` – Lista todos os registros
- `GET /[entidade]/{id}` – Retorna um registro específico
- `POST /[entidade]` – Cria um novo registro
- `PUT /[entidade]/{id}` – Atualiza um registro
- `DELETE /[entidade]/{id}` – Remove um registro

---

## ▶️ Como Executar o Projeto

### Pré-requisitos

- [.NET 7.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- Oracle Database (FIAP ou local)
- Oracle SQL Developer
- Visual Studio ou VS Code

### Passos

1. Clone o repositório:

```bash
git clone https://github.com/Joaopcancian/MottuSprint.git
cd MottuPatio
```
2. Configure a string de conexão no appsettings.json:
```
"ConnectionStrings": {
  "OracleConnection": "User Id=rm555341;Password=070705;Data Source=oracle.fiap.com.br:1521/orcl"
}
```
▶️ Execute o projeto no seu Visual Studio ou VS Code

3. Acesse o swagger:
- http://localhost:5178/swagger/index.html

-COMANDOS DO VIDEO DEVOPS:
```
$RG = "rg-mottu"
$VM_NAME = "vm-mottu"
$LOCATION = "brazilsouth"
$IMAGE = "Ubuntu2204"
$USER = "joao"
$VM_SIZE = "Standard_B1s"
$PASSWORD = "SenhaForte123!"
$NSG = "vm-mottuNSG"

az group create --name rg-mottu --location brazilsouth

az vm create `
  --resource-group $RG `
  --name $VM_NAME `
  --image $IMAGE `
  --admin-username $USER `
  --admin-password $PASSWORD `
  --authentication-type password `
  --size $VM_SIZE

ssh joao@<NOVO_IP>

# Porta 80 - prioridade 1001
az network nsg rule create `
  --resource-group $RG `
  --nsg-name $NSG `
  --name "Allow-Port-80" `
  --priority 1001 `
  --direction Inbound `
  --access Allow `
  --protocol Tcp `
  --destination-port-range 80 `
  --source-address-prefixes '*' `
  --destination-address-prefixes '*'

# Porta 8080 - prioridade 1002
az network nsg rule create `
  --resource-group $RG `
  --nsg-name $NSG `
  --name "Allow-Port-8080" `
  --priority 1002 `
  --direction Inbound `
  --access Allow `
  --protocol Tcp `
  --destination-port-range 8080 `
  --source-address-prefixes '*' `
  --destination-address-prefixes '*'

scp .\install_docker.sh joao@<IP>:/tmp

scp -r `
  "C:\Users\zsnow\Desktop\MottuPatio\Controllers" `
  "C:\Users\zsnow\Desktop\MottuPatio\Models" `
  "C:\Users\zsnow\Desktop\MottuPatio\Data" `
  "C:\Users\zsnow\Desktop\MottuPatio\Program.cs" `
  "C:\Users\zsnow\Desktop\MottuPatio\MottuPatio.csproj" `
  "C:\Users\zsnow\Desktop\MottuPatio\appsettings.json" `
  joao@<IP>:/home/joao/mottu

cd /home/joao/mottu
docker build -t mottu-patio .
http://<IP>:8080/swagger/index.html

```
Autores
João Pedro Cancian Corrêa – RM: 555341
Giulia Camillo - RM: 554473
Caroline de Oliveira - RM: 559123
Desenvolvido como parte da Sprint 1 - 3º Semestre
