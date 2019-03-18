FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /app
COPY . ./
RUN dotnet restore
RUN dotnet publish MyRedisCache.sln --no-restore -c Release -o /app/out
RUN ls

FROM microsoft/dotnet:2.2.1-aspnetcore-runtime-alpine
#ENV ASPNETCORE_URLS=http://+:80
WORKDIR /app
COPY --from=build-env /app/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "MyRedisCache.dll"]