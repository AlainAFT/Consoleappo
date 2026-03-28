using System.ComponentModel;

namespace TiendaConsola;

public class Login
{
    private List<usuario> registro;
    private int pos = -1;
    public Login()
    {
        registro = new List < usuario > ();
    }

  /*  private bool Verificarsiexiste(usuario us)
    {
        for (int  p =0; p < registro.Count();++p)
        {
            if (us.conseguiremail() == registro[p].conseguiremail())
            {  
                us.cambiardeestadoid(p.ToString());
                return true;
            }
        }

        return false;
    }*/
    
  

    public int  verificaremailycontraseña(string e,string c)
    {
        for (int u =0;u<registro.Count();++u)
        {
            if (registro[u].conseguiremail() == e)
            {
                if (registro[u].conseguircontraseña() == c)
                {
                    this.pos = u;
                    return 0;
                }
                return 1;
            }
            
        }

        return -1;
    }
   

    public void CerrarSesion(usuario us )
    {
        usuario cop = us;
        registro[int.Parse(cop.conseguirID())-1] = cop;
       
        us=null;
    }

    
    public int conseguirpos()
    {
        return pos;
    }

    public void pasardatosusuario( out usuario u)
    {
        u = registro[pos];
    }

    public bool verificaremail(string n)
    {
        foreach (usuario u in registro)
        {
            if (u.conseguiremail() == n)
            {
               
                return true;
            }
            
        }

        return false;

    }
    public  bool IniciarSesionCnueva(usuario us)
    {
        if (!verificaremail(us.conseguiremail()))
        {
            us.cambiardeestadoid((registro.Count()+1).ToString());
            registro.Add(us);
            return true;
        }

        return false;//existe esa info en la lista de usuarios

    }

    public List<usuario> devolverlistadeusuarios()
    {
        return registro;
    }

    public bool CambiarEmail(usuario us,string e)
    {

        foreach (usuario p in registro)
        {
            if (us.conseguirID() != p.conseguirID())
            {
                if (e == p.conseguiremail())
                {
                    return false;
                }
            }
        }
         
        us.cambiardeestadoemail(e);
        return true;
    }

    public usuario EncontrarUsuario(string cn)
    {
        
        foreach (usuario p in registro)
        {
            if(cn == p.conseguirID() || cn == p.conseguiremail())
            {
                return p;
            }
        }

        return null;
    }

    public void guardarinfodeusario(usuario actualizado)
    {
        registro[int.Parse(actualizado.conseguirID())-1] = actualizado;
    }

    
    
}