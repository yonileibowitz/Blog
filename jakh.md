# Just another Kusto hacker (*JAKH*)

What would you guess the following query prints?

```
print a='😉🐮🔬🐭🐾😚🐧🐨🌭🐡🐞🐫🔾🌊😮🐬🔭🌨🌾🌡🐚😜🌤🌞🌫'
| extend a=extractall('(.)', a)
| mvexpand a
| extend a=substring(base64_encodestring(strcat('abracadabra', a)), 19)
| summarize Message=replace(@'[+]', ' ', replace(@'[[",\]]', "", tostring(makelist(a))))
```

TODO: add content
