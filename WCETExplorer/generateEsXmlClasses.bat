@echo off
PATH=C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\x64;%PATH%
xsd.exe ES\es_config.xsd /classes /namespace:Gui.Classes /language:CS /out:Gui\Classes /nologo
