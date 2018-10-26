# Just another Kusto hacker *(JAKH)*

What would you guess the following query prints?

[*Click here to run*](https://dataexplorer.azure.com/clusters/help/databases/Samples?query=H4sIAAAAAAAAA01OS4rCQBDde4omm+7GIAgy4EKYC8wJVKSSFBLMj3QrIl5AycKFCxGZIAgK6hxhzpQjzOvBhYvXVbxfdVHGmRU0kE192DT17qep9w/MJ/AL7oh5BW5NXTnuDHwDd/igV1t4kNkhs4deOZ/jnQ/Zwwn7BUCmusvWWvDSchbhIpaSQktJoqTqaOkL0tDTBS8Lco53s5kHxuKrUxWQ4Y/ehLMwj/jFYYRklaQAjRS58V+nfdHtu1IzT1Mq4xWLLzaGpjwouUgoZPUph+0xzFLgeSOHnj8aO8HzfGHz16GUZpzExip0a/0HguPVQDwBAAA=)
```
print a='😉🐮🔬🐭🐾😚🐧🐨🌭🐡🐞🐫🔾🌊😮🐬🔭🌨🌾🌡🐚😜🌤🌞🌫'
| extend a=extractall('(.)', a)
| mvexpand a
| extend a=substring(base64_encodestring(strcat('abracadabra', a)), 19)
| summarize Message=replace(@'[+]', ' ', replace(@'[[",\]]', "", tostring(makelist(a))))
```

TODO: add content
