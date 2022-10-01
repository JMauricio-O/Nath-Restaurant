using NathRestaurant.Ventas.AccesoADatos;
using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.LogicaDeNegocio
{
    public class CombosBL
    {
        public async Task<int> AgregarAsync(Combos pCombos)
        {
            return await CombosDAL.AgregarAsync(pCombos);
        }
        public async Task<int> ModificarAsync(Combos pCombos)
        {
            return await CombosDAL.ModificarAsync(pCombos);
        }
        public async Task<int> EliminarAsync(Combos pCombos)
        {
            return await CombosDAL.EliminarAsync(pCombos);
        }
        public async Task<Combos> ObtenerPorIdAsync(Combos pCombos)
        {
            return await CombosDAL.ObtenerPorIdAsync(pCombos);
        }
        public async Task<List<Combos>> ObtenerTodosAsync()
        {
            return await CombosDAL.ObtenerTodosAsync();
        }
        public async Task<List<Combos>> BuscarAsync(Combos pCombos)
        {
            return await CombosDAL.BuscarAsync(pCombos);
        }
        public async Task<List<Combos>> BuscarIncluirProductoAsync(Combos pCombos)
        {
            return await CombosDAL.BuscarIncluirProductoAsync(pCombos);
        }
    }
}
