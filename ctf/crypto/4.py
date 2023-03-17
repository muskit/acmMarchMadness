import string
import base64

# custom encoding function
def EncodeCustomBase64(stringToBeEncoded,custom_b64):
   standard_b64 = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/='
   encoded = base64.b64encode(stringToBeEncoded)
   final_encoded = ""
   for ch in encoded:
        if (ch in custom_b64):
            final_encoded += custom_b64[standard_b64.index(str(ch))]
        elif (ch == '='):
            final_encoded += '='
   print(final_encoded)

# custom decoding function
def DecodeCustomBase64(stringToBeDecoded,custom_b64):
   standard_b64 = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/='
   temp_decoded = ""
   for ch in stringToBeDecoded:
        if (ch in custom_b64):
            temp_decoded += standard_b64[custom_b64.index(str(ch))]
        elif (ch == '='):
            temp_decoded += '='
   decoded = base64.b64decode(temp_decoded)
   print(decoded)

print ("#########################################################")
print ("### CAB-64 - Custom Alphabet Base64 [en|de]coder v0.1 ###")
print ("#########################################################")

while True:
# enter custom base64 alphabet i.e"QpaZIivj4ndG=H021y+NO5RSTxPgUz67FMhYq8b3wemKfkJLBocCDrs9VtWXlEuA"
    custom_base_64 = input("> Enter your custom base64 alphabet (must be 64 char long):\n")[0:64]
    print(len(custom_base_64))
    if len(custom_base_64) != 64:
        print ("\n\t - [!] incorrect alphabet length - alphabet must be 64 char long\n")
    else:
        while True:
            action = input("> Are you Encoding (E) or Decoding (D)\n")
            if action != "D" and action != "E" and action !="e" and action!="d":
                print ("\n\t[!] incorrect selection")
            elif action == "E" or action =="e":
                cleartext = input("> Enter your cleartext that needs to be encoded:\n")
                EncodeCustomBase64(cleartext,custom_base_64)
            elif action == "D" or action =="d":
                ciphertext = input("> Enter your ciphertext that needs to be deencoded\n")
                DecodeCustomBase64(ciphertext,custom_base_64)