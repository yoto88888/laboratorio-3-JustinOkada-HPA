using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public static class Utilidades
{
    public static bool EsCorreoValido(string email)
    {
        if (EstaEnBlanco(email))
        {
            return false;
        }
        string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, patron);
    }
    public static bool EstaEnBlanco(string texto)
    {
        return string.IsNullOrWhiteSpace(texto);
    }
}
