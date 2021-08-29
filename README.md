## **Projeto da Disciplina de Tópicos de Segurança**

***

### **TeSP de Programação de Sistemas de Informação**

#### **Instituto Politécnico de Leiria 2020/2021**

***

**Grupo D:**

**2201115** Artur Quaresma

**2200428** Marcelo Marques

**2200426** Vasco Silva

***

O objetivo deste projeto é o desenvolvimento de um chat com troca de mensagens e ficheiros de forma segura, em C#. O  trabalho  será  composto  por  um  módulo  *cliente*  e  por  um  módulo *servidor*,  com  as  seguintes  características base:

- O **cliente**, *com User Interface (UI)*, pode:
  - Enviar a sua chave pública;
  - Autenticar-se no servidor fornecendo as credenciais;
  - Enviar e receber as mensagens de conversação e ficheiros;
  - Tornar todas as comunicações o mais seguras possível;
  - Validar todas as mensagens e ficheiros trocados com recurso a assinaturas digitais.

- O **servidor**, *sem UI*, permite:
  - Receber ligações de cliente;
  - Guardar a chave pública do cliente;
  - Autenticar um utilizador já registado no sistema;
  - Validar as assinaturas do cliente;
  - Enviar e receber as mensagens de conversação e ficheiros partilhados de forma segura;
  - Receber e processar os dados relativos às mensagens e ficheiros partilhados de forma segura.