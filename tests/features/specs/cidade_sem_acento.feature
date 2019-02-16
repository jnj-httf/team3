#language: pt

@cidade_sem_acento

Funcionalidade: Quando o nome de uma cidade que tem acento é digitada sem acento, a lista de ubs é retornada sem problemas

Cenário: Lista de UBS é retornada normalmente quando cidade sem acento é digitada
Dado que uma cidade tem acento no nome
Quando digito o nome da cidade sem acento
Entao verifico se as informações da cidade são retornadas normalmente