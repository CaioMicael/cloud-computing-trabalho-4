# API de Monitoramento de Segurança

API REST desenvolvida em ASP.NET Core 9 para a disciplina de Cloud Computing. Simula um sistema de monitoramento de eventos de segurança.

## Pré-requisitos

| Sem Docker | Com Docker |
|---|---|
| [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) | [Docker](https://www.docker.com/products/docker-desktop) |

---

## Rodando sem Docker

```bash
dotnet run --project cloud-computing-trabalho-4.csproj
```

A API ficará disponível em `http://localhost:5212`.

---

## Rodando com Docker

**Build da imagem:**
```bash
docker build -t monitoramento-api .
```

**Subir o container:**
```bash
docker run -p 8080:8080 monitoramento-api
```

A API ficará disponível em `http://localhost:8080`.

---

## Endpoints

| Método | Rota | Descrição | Respostas |
|---|---|---|---|
| `GET` | `/status` | Verifica se a API está no ar | `200 OK` |
| `GET` | `/log/eventos` | Lista os 20 eventos de segurança | `200 OK`, `204 No Content` |
| `GET` | `/log/eventos/{id}` | Retorna um evento pelo ID | `200 OK`, `404 Not Found` |

### Exemplos

```bash
# Status da API
curl http://localhost:8080/status

# Listar eventos
curl http://localhost:8080/log/eventos

# Buscar evento por ID
curl http://localhost:8080/log/eventos/1

# ID inexistente (retorna 404)
curl http://localhost:8080/log/eventos/999
```

---

## Testes

```bash
dotnet test TestesUnitarios/TestesUnitarios.csproj
```
