// -----------------------------------------------------------------------------
//
// PREVIOUS MOVE
//
// -----------------------------------------------------------------------------
using System;
using RuntimeXNA.RunLoop;
using RuntimeXNA.Objects;
namespace RuntimeXNA.Actions
{
	
	public class ACT_EXTPREVMOVE:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			if (pHo.rom != null)
			{
				pHo.rom.previousMovement(pHo);
			}
		}
	}
}