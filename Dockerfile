FROM mcr.microsoft.com/dotnet/aspnet:5.0
ENV ASPNETCORE_URLS=http://*:5001
WORKDIR /app
EXPOSE 5001

COPY build .
ENTRYPOINT ["dotnet", "todo_api.Api.dll"]
