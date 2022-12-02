@echo off

pushd %~dp0

dotnet build ./DeaDXoxoton.sln
cd new-year-game && npm i && npm run build

popd