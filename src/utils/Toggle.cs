// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwToggle
// ---------------------------------------------------------------------------- //


//Simple flipflop class
namespace Exp2.src.utils
{
    public class cwToggle
    {
        bool state = false;
        public bool toggle()
        {
            if (state)
            {
                return state = false;
            }
            return state = true;
        }



    }
}
