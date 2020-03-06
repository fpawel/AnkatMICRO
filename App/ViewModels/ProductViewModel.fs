namespace Ankat.ViewModel

open Ankat
open Pneumo

type Product(p, getProdType, getPgs, partyId) =

    inherit ViewModel.Product1(p, getProdType, getPgs, partyId) 
    override x.RaisePropertyChanged propertyName = 
        ViewModelBase.raisePropertyChanged x propertyName

    member x.Var_LIN0_0_CoutCh0
        with get () = x.getVarUi (LinPt(Sens1,Lin1), CoutCh0)
        and set value = x.setVarUi (LinPt(Sens1,Lin1), CoutCh0) value

    member x.Var_LIN0_1_CoutCh0
        with get () = x.getVarUi (LinPt(Sens1,Lin2), CoutCh0)
        and set value = x.setVarUi (LinPt(Sens1,Lin2), CoutCh0) value

    member x.Var_LIN0_2_CoutCh0
        with get () = x.getVarUi (LinPt(Sens1,Lin3), CoutCh0)
        and set value = x.setVarUi (LinPt(Sens1,Lin3), CoutCh0) value

    member x.Var_LIN0_3_CoutCh0
        with get () = x.getVarUi (LinPt(Sens1,Lin4), CoutCh0)
        and set value = x.setVarUi (LinPt(Sens1,Lin4), CoutCh0) value

    member x.Var_LIN1_0_CoutCh1
        with get () = x.getVarUi (LinPt(Sens2,Lin1), CoutCh1)
        and set value = x.setVarUi (LinPt(Sens2,Lin1), CoutCh1) value

    member x.Var_LIN1_1_CoutCh1
        with get () = x.getVarUi (LinPt(Sens2,Lin2), CoutCh1)
        and set value = x.setVarUi (LinPt(Sens2,Lin2), CoutCh1) value

    member x.Var_LIN1_2_CoutCh1
        with get () = x.getVarUi (LinPt(Sens2,Lin3), CoutCh1)
        and set value = x.setVarUi (LinPt(Sens2,Lin3), CoutCh1) value

    member x.Var_LIN1_3_CoutCh1
        with get () = x.getVarUi (LinPt(Sens2,Lin4), CoutCh1)
        and set value = x.setVarUi (LinPt(Sens2,Lin4), CoutCh1) value

    member x.Var_T00_0_TppCh0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoLow), TppCh0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoLow), TppCh0) value

    member x.Var_T00_0_Var1Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoLow), Var1Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoLow), Var1Ch0) value

    member x.Var_T00_0_Var2Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoLow), Var2Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoLow), Var2Ch0) value

    member x.Var_T00_0_Var3Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoLow), Var3Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoLow), Var3Ch0) value

    member x.Var_T00_0_Uw_Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoLow), Uw_Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoLow), Uw_Ch0) value

    member x.Var_T00_0_Ur_Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoLow), Ur_Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoLow), Ur_Ch0) value

    member x.Var_T00_0_WORK0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoLow), WORK0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoLow), WORK0) value

    member x.Var_T00_0_REF0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoLow), REF0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoLow), REF0) value

    member x.Var_T00_0_CCh0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoLow), CCh0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoLow), CCh0) value

    member x.Var_T00_0_CoutCh0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoLow), CoutCh0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoLow), CoutCh0) value

    member x.Var_T00_1_TppCh0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoNorm), TppCh0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoNorm), TppCh0) value

    member x.Var_T00_1_Var1Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoNorm), Var1Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoNorm), Var1Ch0) value

    member x.Var_T00_1_Var2Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoNorm), Var2Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoNorm), Var2Ch0) value

    member x.Var_T00_1_Var3Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoNorm), Var3Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoNorm), Var3Ch0) value

    member x.Var_T00_1_Uw_Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoNorm), Uw_Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoNorm), Uw_Ch0) value

    member x.Var_T00_1_Ur_Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoNorm), Ur_Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoNorm), Ur_Ch0) value

    member x.Var_T00_1_WORK0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoNorm), WORK0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoNorm), WORK0) value

    member x.Var_T00_1_REF0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoNorm), REF0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoNorm), REF0) value

    member x.Var_T00_1_CCh0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoNorm), CCh0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoNorm), CCh0) value

    member x.Var_T00_1_CoutCh0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoNorm), CoutCh0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoNorm), CoutCh0) value

    member x.Var_T00_2_TppCh0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoHigh), TppCh0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoHigh), TppCh0) value

    member x.Var_T00_2_Var1Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoHigh), Var1Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoHigh), Var1Ch0) value

    member x.Var_T00_2_Var2Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoHigh), Var2Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoHigh), Var2Ch0) value

    member x.Var_T00_2_Var3Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoHigh), Var3Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoHigh), Var3Ch0) value

    member x.Var_T00_2_Uw_Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoHigh), Uw_Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoHigh), Uw_Ch0) value

    member x.Var_T00_2_Ur_Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoHigh), Ur_Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoHigh), Ur_Ch0) value

    member x.Var_T00_2_WORK0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoHigh), WORK0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoHigh), WORK0) value

    member x.Var_T00_2_REF0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoHigh), REF0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoHigh), REF0) value

    member x.Var_T00_2_CCh0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoHigh), CCh0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoHigh), CCh0) value

    member x.Var_T00_2_CoutCh0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleBeg, TermoHigh), CoutCh0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleBeg, TermoHigh), CoutCh0) value

    member x.Var_TK0_0_TppCh0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoLow), TppCh0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoLow), TppCh0) value

    member x.Var_TK0_0_Var1Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoLow), Var1Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoLow), Var1Ch0) value

    member x.Var_TK0_0_Var2Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoLow), Var2Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoLow), Var2Ch0) value

    member x.Var_TK0_0_Var3Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoLow), Var3Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoLow), Var3Ch0) value

    member x.Var_TK0_0_Uw_Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoLow), Uw_Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoLow), Uw_Ch0) value

    member x.Var_TK0_0_Ur_Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoLow), Ur_Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoLow), Ur_Ch0) value

    member x.Var_TK0_0_WORK0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoLow), WORK0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoLow), WORK0) value

    member x.Var_TK0_0_REF0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoLow), REF0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoLow), REF0) value

    member x.Var_TK0_0_CCh0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoLow), CCh0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoLow), CCh0) value

    member x.Var_TK0_0_CoutCh0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoLow), CoutCh0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoLow), CoutCh0) value

    member x.Var_TK0_1_TppCh0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoNorm), TppCh0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoNorm), TppCh0) value

    member x.Var_TK0_1_Var1Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoNorm), Var1Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoNorm), Var1Ch0) value

    member x.Var_TK0_1_Var2Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoNorm), Var2Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoNorm), Var2Ch0) value

    member x.Var_TK0_1_Var3Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoNorm), Var3Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoNorm), Var3Ch0) value

    member x.Var_TK0_1_Uw_Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoNorm), Uw_Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoNorm), Uw_Ch0) value

    member x.Var_TK0_1_Ur_Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoNorm), Ur_Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoNorm), Ur_Ch0) value

    member x.Var_TK0_1_WORK0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoNorm), WORK0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoNorm), WORK0) value

    member x.Var_TK0_1_REF0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoNorm), REF0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoNorm), REF0) value

    member x.Var_TK0_1_CCh0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoNorm), CCh0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoNorm), CCh0) value

    member x.Var_TK0_1_CoutCh0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoNorm), CoutCh0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoNorm), CoutCh0) value

    member x.Var_TK0_2_TppCh0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoHigh), TppCh0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoHigh), TppCh0) value

    member x.Var_TK0_2_Var1Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoHigh), Var1Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoHigh), Var1Ch0) value

    member x.Var_TK0_2_Var2Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoHigh), Var2Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoHigh), Var2Ch0) value

    member x.Var_TK0_2_Var3Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoHigh), Var3Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoHigh), Var3Ch0) value

    member x.Var_TK0_2_Uw_Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoHigh), Uw_Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoHigh), Uw_Ch0) value

    member x.Var_TK0_2_Ur_Ch0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoHigh), Ur_Ch0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoHigh), Ur_Ch0) value

    member x.Var_TK0_2_WORK0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoHigh), WORK0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoHigh), WORK0) value

    member x.Var_TK0_2_REF0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoHigh), REF0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoHigh), REF0) value

    member x.Var_TK0_2_CCh0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoHigh), CCh0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoHigh), CCh0) value

    member x.Var_TK0_2_CoutCh0
        with get () = x.getVarUi (TermoScalePt(Sens1, ScaleEnd, TermoHigh), CoutCh0)
        and set value = x.setVarUi (TermoScalePt(Sens1, ScaleEnd, TermoHigh), CoutCh0) value

    member x.Var_T01_0_TppCh1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoLow), TppCh1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoLow), TppCh1) value

    member x.Var_T01_0_Var1Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoLow), Var1Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoLow), Var1Ch1) value

    member x.Var_T01_0_Var2Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoLow), Var2Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoLow), Var2Ch1) value

    member x.Var_T01_0_Var3Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoLow), Var3Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoLow), Var3Ch1) value

    member x.Var_T01_0_Uw_Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoLow), Uw_Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoLow), Uw_Ch1) value

    member x.Var_T01_0_Ur_Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoLow), Ur_Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoLow), Ur_Ch1) value

    member x.Var_T01_0_WORK1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoLow), WORK1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoLow), WORK1) value

    member x.Var_T01_0_REF1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoLow), REF1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoLow), REF1) value

    member x.Var_T01_0_CCh1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoLow), CCh1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoLow), CCh1) value

    member x.Var_T01_0_CoutCh1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoLow), CoutCh1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoLow), CoutCh1) value

    member x.Var_T01_1_TppCh1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoNorm), TppCh1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoNorm), TppCh1) value

    member x.Var_T01_1_Var1Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoNorm), Var1Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoNorm), Var1Ch1) value

    member x.Var_T01_1_Var2Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoNorm), Var2Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoNorm), Var2Ch1) value

    member x.Var_T01_1_Var3Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoNorm), Var3Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoNorm), Var3Ch1) value

    member x.Var_T01_1_Uw_Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoNorm), Uw_Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoNorm), Uw_Ch1) value

    member x.Var_T01_1_Ur_Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoNorm), Ur_Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoNorm), Ur_Ch1) value

    member x.Var_T01_1_WORK1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoNorm), WORK1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoNorm), WORK1) value

    member x.Var_T01_1_REF1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoNorm), REF1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoNorm), REF1) value

    member x.Var_T01_1_CCh1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoNorm), CCh1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoNorm), CCh1) value

    member x.Var_T01_1_CoutCh1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoNorm), CoutCh1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoNorm), CoutCh1) value

    member x.Var_T01_2_TppCh1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoHigh), TppCh1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoHigh), TppCh1) value

    member x.Var_T01_2_Var1Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoHigh), Var1Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoHigh), Var1Ch1) value

    member x.Var_T01_2_Var2Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoHigh), Var2Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoHigh), Var2Ch1) value

    member x.Var_T01_2_Var3Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoHigh), Var3Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoHigh), Var3Ch1) value

    member x.Var_T01_2_Uw_Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoHigh), Uw_Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoHigh), Uw_Ch1) value

    member x.Var_T01_2_Ur_Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoHigh), Ur_Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoHigh), Ur_Ch1) value

    member x.Var_T01_2_WORK1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoHigh), WORK1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoHigh), WORK1) value

    member x.Var_T01_2_REF1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoHigh), REF1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoHigh), REF1) value

    member x.Var_T01_2_CCh1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoHigh), CCh1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoHigh), CCh1) value

    member x.Var_T01_2_CoutCh1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleBeg, TermoHigh), CoutCh1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleBeg, TermoHigh), CoutCh1) value

    member x.Var_TK1_0_TppCh1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoLow), TppCh1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoLow), TppCh1) value

    member x.Var_TK1_0_Var1Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoLow), Var1Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoLow), Var1Ch1) value

    member x.Var_TK1_0_Var2Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoLow), Var2Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoLow), Var2Ch1) value

    member x.Var_TK1_0_Var3Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoLow), Var3Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoLow), Var3Ch1) value

    member x.Var_TK1_0_Uw_Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoLow), Uw_Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoLow), Uw_Ch1) value

    member x.Var_TK1_0_Ur_Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoLow), Ur_Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoLow), Ur_Ch1) value

    member x.Var_TK1_0_WORK1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoLow), WORK1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoLow), WORK1) value

    member x.Var_TK1_0_REF1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoLow), REF1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoLow), REF1) value

    member x.Var_TK1_0_CCh1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoLow), CCh1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoLow), CCh1) value

    member x.Var_TK1_0_CoutCh1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoLow), CoutCh1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoLow), CoutCh1) value

    member x.Var_TK1_1_TppCh1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoNorm), TppCh1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoNorm), TppCh1) value

    member x.Var_TK1_1_Var1Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoNorm), Var1Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoNorm), Var1Ch1) value

    member x.Var_TK1_1_Var2Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoNorm), Var2Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoNorm), Var2Ch1) value

    member x.Var_TK1_1_Var3Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoNorm), Var3Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoNorm), Var3Ch1) value

    member x.Var_TK1_1_Uw_Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoNorm), Uw_Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoNorm), Uw_Ch1) value

    member x.Var_TK1_1_Ur_Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoNorm), Ur_Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoNorm), Ur_Ch1) value

    member x.Var_TK1_1_WORK1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoNorm), WORK1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoNorm), WORK1) value

    member x.Var_TK1_1_REF1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoNorm), REF1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoNorm), REF1) value

    member x.Var_TK1_1_CCh1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoNorm), CCh1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoNorm), CCh1) value

    member x.Var_TK1_1_CoutCh1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoNorm), CoutCh1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoNorm), CoutCh1) value

    member x.Var_TK1_2_TppCh1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoHigh), TppCh1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoHigh), TppCh1) value

    member x.Var_TK1_2_Var1Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoHigh), Var1Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoHigh), Var1Ch1) value

    member x.Var_TK1_2_Var2Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoHigh), Var2Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoHigh), Var2Ch1) value

    member x.Var_TK1_2_Var3Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoHigh), Var3Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoHigh), Var3Ch1) value

    member x.Var_TK1_2_Uw_Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoHigh), Uw_Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoHigh), Uw_Ch1) value

    member x.Var_TK1_2_Ur_Ch1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoHigh), Ur_Ch1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoHigh), Ur_Ch1) value

    member x.Var_TK1_2_WORK1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoHigh), WORK1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoHigh), WORK1) value

    member x.Var_TK1_2_REF1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoHigh), REF1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoHigh), REF1) value

    member x.Var_TK1_2_CCh1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoHigh), CCh1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoHigh), CCh1) value

    member x.Var_TK1_2_CoutCh1
        with get () = x.getVarUi (TermoScalePt(Sens2, ScaleEnd, TermoHigh), CoutCh1)
        and set value = x.setVarUi (TermoScalePt(Sens2, ScaleEnd, TermoHigh), CoutCh1) value

    member x.Var_TEST0_0_0_TppCh0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoLow), TppCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoLow), TppCh0) value

    member x.Var_TEST0_0_0_Var1Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoLow), Var1Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoLow), Var1Ch0) value

    member x.Var_TEST0_0_0_Var2Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoLow), Var2Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoLow), Var2Ch0) value

    member x.Var_TEST0_0_0_Var3Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoLow), Var3Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoLow), Var3Ch0) value

    member x.Var_TEST0_0_0_Uw_Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoLow), Uw_Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoLow), Uw_Ch0) value

    member x.Var_TEST0_0_0_Ur_Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoLow), Ur_Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoLow), Ur_Ch0) value

    member x.Var_TEST0_0_0_WORK0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoLow), WORK0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoLow), WORK0) value

    member x.Var_TEST0_0_0_REF0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoLow), REF0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoLow), REF0) value

    member x.Var_TEST0_0_0_CCh0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoLow), CCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoLow), CCh0) value

    member x.Var_TEST0_0_0_CoutCh0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoLow), CoutCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoLow), CoutCh0) value

    member x.Var_TEST0_0_1_TppCh0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoNorm), TppCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoNorm), TppCh0) value

    member x.Var_TEST0_0_1_Var1Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoNorm), Var1Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoNorm), Var1Ch0) value

    member x.Var_TEST0_0_1_Var2Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoNorm), Var2Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoNorm), Var2Ch0) value

    member x.Var_TEST0_0_1_Var3Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoNorm), Var3Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoNorm), Var3Ch0) value

    member x.Var_TEST0_0_1_Uw_Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoNorm), Uw_Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoNorm), Uw_Ch0) value

    member x.Var_TEST0_0_1_Ur_Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoNorm), Ur_Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoNorm), Ur_Ch0) value

    member x.Var_TEST0_0_1_WORK0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoNorm), WORK0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoNorm), WORK0) value

    member x.Var_TEST0_0_1_REF0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoNorm), REF0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoNorm), REF0) value

    member x.Var_TEST0_0_1_CCh0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoNorm), CCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoNorm), CCh0) value

    member x.Var_TEST0_0_1_CoutCh0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoNorm), CoutCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoNorm), CoutCh0) value

    member x.Var_TEST0_0_2_TppCh0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoHigh), TppCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoHigh), TppCh0) value

    member x.Var_TEST0_0_2_Var1Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoHigh), Var1Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoHigh), Var1Ch0) value

    member x.Var_TEST0_0_2_Var2Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoHigh), Var2Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoHigh), Var2Ch0) value

    member x.Var_TEST0_0_2_Var3Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoHigh), Var3Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoHigh), Var3Ch0) value

    member x.Var_TEST0_0_2_Uw_Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoHigh), Uw_Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoHigh), Uw_Ch0) value

    member x.Var_TEST0_0_2_Ur_Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoHigh), Ur_Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoHigh), Ur_Ch0) value

    member x.Var_TEST0_0_2_WORK0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoHigh), WORK0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoHigh), WORK0) value

    member x.Var_TEST0_0_2_REF0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoHigh), REF0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoHigh), REF0) value

    member x.Var_TEST0_0_2_CCh0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoHigh), CCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoHigh), CCh0) value

    member x.Var_TEST0_0_2_CoutCh0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoHigh), CoutCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleBeg, TermoHigh), CoutCh0) value

    member x.Var_TEST0_1_0_TppCh0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoLow), TppCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoLow), TppCh0) value

    member x.Var_TEST0_1_0_Var1Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoLow), Var1Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoLow), Var1Ch0) value

    member x.Var_TEST0_1_0_Var2Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoLow), Var2Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoLow), Var2Ch0) value

    member x.Var_TEST0_1_0_Var3Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoLow), Var3Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoLow), Var3Ch0) value

    member x.Var_TEST0_1_0_Uw_Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoLow), Uw_Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoLow), Uw_Ch0) value

    member x.Var_TEST0_1_0_Ur_Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoLow), Ur_Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoLow), Ur_Ch0) value

    member x.Var_TEST0_1_0_WORK0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoLow), WORK0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoLow), WORK0) value

    member x.Var_TEST0_1_0_REF0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoLow), REF0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoLow), REF0) value

    member x.Var_TEST0_1_0_CCh0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoLow), CCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoLow), CCh0) value

    member x.Var_TEST0_1_0_CoutCh0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoLow), CoutCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoLow), CoutCh0) value

    member x.Var_TEST0_1_1_TppCh0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoNorm), TppCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoNorm), TppCh0) value

    member x.Var_TEST0_1_1_Var1Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoNorm), Var1Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoNorm), Var1Ch0) value

    member x.Var_TEST0_1_1_Var2Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoNorm), Var2Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoNorm), Var2Ch0) value

    member x.Var_TEST0_1_1_Var3Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoNorm), Var3Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoNorm), Var3Ch0) value

    member x.Var_TEST0_1_1_Uw_Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoNorm), Uw_Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoNorm), Uw_Ch0) value

    member x.Var_TEST0_1_1_Ur_Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoNorm), Ur_Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoNorm), Ur_Ch0) value

    member x.Var_TEST0_1_1_WORK0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoNorm), WORK0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoNorm), WORK0) value

    member x.Var_TEST0_1_1_REF0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoNorm), REF0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoNorm), REF0) value

    member x.Var_TEST0_1_1_CCh0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoNorm), CCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoNorm), CCh0) value

    member x.Var_TEST0_1_1_CoutCh0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoNorm), CoutCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoNorm), CoutCh0) value

    member x.Var_TEST0_1_2_TppCh0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoHigh), TppCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoHigh), TppCh0) value

    member x.Var_TEST0_1_2_Var1Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoHigh), Var1Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoHigh), Var1Ch0) value

    member x.Var_TEST0_1_2_Var2Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoHigh), Var2Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoHigh), Var2Ch0) value

    member x.Var_TEST0_1_2_Var3Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoHigh), Var3Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoHigh), Var3Ch0) value

    member x.Var_TEST0_1_2_Uw_Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoHigh), Uw_Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoHigh), Uw_Ch0) value

    member x.Var_TEST0_1_2_Ur_Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoHigh), Ur_Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoHigh), Ur_Ch0) value

    member x.Var_TEST0_1_2_WORK0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoHigh), WORK0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoHigh), WORK0) value

    member x.Var_TEST0_1_2_REF0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoHigh), REF0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoHigh), REF0) value

    member x.Var_TEST0_1_2_CCh0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoHigh), CCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoHigh), CCh0) value

    member x.Var_TEST0_1_2_CoutCh0
        with get () = x.getVarUi (Test(Sens1, ScaleMid, TermoHigh), CoutCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleMid, TermoHigh), CoutCh0) value

    member x.Var_TEST0_2_0_TppCh0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoLow), TppCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoLow), TppCh0) value

    member x.Var_TEST0_2_0_Var1Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoLow), Var1Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoLow), Var1Ch0) value

    member x.Var_TEST0_2_0_Var2Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoLow), Var2Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoLow), Var2Ch0) value

    member x.Var_TEST0_2_0_Var3Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoLow), Var3Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoLow), Var3Ch0) value

    member x.Var_TEST0_2_0_Uw_Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoLow), Uw_Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoLow), Uw_Ch0) value

    member x.Var_TEST0_2_0_Ur_Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoLow), Ur_Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoLow), Ur_Ch0) value

    member x.Var_TEST0_2_0_WORK0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoLow), WORK0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoLow), WORK0) value

    member x.Var_TEST0_2_0_REF0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoLow), REF0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoLow), REF0) value

    member x.Var_TEST0_2_0_CCh0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoLow), CCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoLow), CCh0) value

    member x.Var_TEST0_2_0_CoutCh0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoLow), CoutCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoLow), CoutCh0) value

    member x.Var_TEST0_2_1_TppCh0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoNorm), TppCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoNorm), TppCh0) value

    member x.Var_TEST0_2_1_Var1Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoNorm), Var1Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoNorm), Var1Ch0) value

    member x.Var_TEST0_2_1_Var2Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoNorm), Var2Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoNorm), Var2Ch0) value

    member x.Var_TEST0_2_1_Var3Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoNorm), Var3Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoNorm), Var3Ch0) value

    member x.Var_TEST0_2_1_Uw_Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoNorm), Uw_Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoNorm), Uw_Ch0) value

    member x.Var_TEST0_2_1_Ur_Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoNorm), Ur_Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoNorm), Ur_Ch0) value

    member x.Var_TEST0_2_1_WORK0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoNorm), WORK0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoNorm), WORK0) value

    member x.Var_TEST0_2_1_REF0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoNorm), REF0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoNorm), REF0) value

    member x.Var_TEST0_2_1_CCh0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoNorm), CCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoNorm), CCh0) value

    member x.Var_TEST0_2_1_CoutCh0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoNorm), CoutCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoNorm), CoutCh0) value

    member x.Var_TEST0_2_2_TppCh0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoHigh), TppCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoHigh), TppCh0) value

    member x.Var_TEST0_2_2_Var1Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoHigh), Var1Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoHigh), Var1Ch0) value

    member x.Var_TEST0_2_2_Var2Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoHigh), Var2Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoHigh), Var2Ch0) value

    member x.Var_TEST0_2_2_Var3Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoHigh), Var3Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoHigh), Var3Ch0) value

    member x.Var_TEST0_2_2_Uw_Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoHigh), Uw_Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoHigh), Uw_Ch0) value

    member x.Var_TEST0_2_2_Ur_Ch0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoHigh), Ur_Ch0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoHigh), Ur_Ch0) value

    member x.Var_TEST0_2_2_WORK0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoHigh), WORK0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoHigh), WORK0) value

    member x.Var_TEST0_2_2_REF0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoHigh), REF0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoHigh), REF0) value

    member x.Var_TEST0_2_2_CCh0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoHigh), CCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoHigh), CCh0) value

    member x.Var_TEST0_2_2_CoutCh0
        with get () = x.getVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoHigh), CoutCh0)
        and set value = x.setVarUi (Test(Sens1, ScaleEdge ScaleEnd, TermoHigh), CoutCh0) value

    member x.Var_TEST1_0_0_TppCh1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoLow), TppCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoLow), TppCh1) value

    member x.Var_TEST1_0_0_Var1Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoLow), Var1Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoLow), Var1Ch1) value

    member x.Var_TEST1_0_0_Var2Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoLow), Var2Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoLow), Var2Ch1) value

    member x.Var_TEST1_0_0_Var3Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoLow), Var3Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoLow), Var3Ch1) value

    member x.Var_TEST1_0_0_Uw_Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoLow), Uw_Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoLow), Uw_Ch1) value

    member x.Var_TEST1_0_0_Ur_Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoLow), Ur_Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoLow), Ur_Ch1) value

    member x.Var_TEST1_0_0_WORK1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoLow), WORK1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoLow), WORK1) value

    member x.Var_TEST1_0_0_REF1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoLow), REF1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoLow), REF1) value

    member x.Var_TEST1_0_0_CCh1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoLow), CCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoLow), CCh1) value

    member x.Var_TEST1_0_0_CoutCh1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoLow), CoutCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoLow), CoutCh1) value

    member x.Var_TEST1_0_1_TppCh1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoNorm), TppCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoNorm), TppCh1) value

    member x.Var_TEST1_0_1_Var1Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoNorm), Var1Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoNorm), Var1Ch1) value

    member x.Var_TEST1_0_1_Var2Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoNorm), Var2Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoNorm), Var2Ch1) value

    member x.Var_TEST1_0_1_Var3Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoNorm), Var3Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoNorm), Var3Ch1) value

    member x.Var_TEST1_0_1_Uw_Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoNorm), Uw_Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoNorm), Uw_Ch1) value

    member x.Var_TEST1_0_1_Ur_Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoNorm), Ur_Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoNorm), Ur_Ch1) value

    member x.Var_TEST1_0_1_WORK1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoNorm), WORK1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoNorm), WORK1) value

    member x.Var_TEST1_0_1_REF1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoNorm), REF1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoNorm), REF1) value

    member x.Var_TEST1_0_1_CCh1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoNorm), CCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoNorm), CCh1) value

    member x.Var_TEST1_0_1_CoutCh1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoNorm), CoutCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoNorm), CoutCh1) value

    member x.Var_TEST1_0_2_TppCh1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoHigh), TppCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoHigh), TppCh1) value

    member x.Var_TEST1_0_2_Var1Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoHigh), Var1Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoHigh), Var1Ch1) value

    member x.Var_TEST1_0_2_Var2Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoHigh), Var2Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoHigh), Var2Ch1) value

    member x.Var_TEST1_0_2_Var3Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoHigh), Var3Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoHigh), Var3Ch1) value

    member x.Var_TEST1_0_2_Uw_Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoHigh), Uw_Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoHigh), Uw_Ch1) value

    member x.Var_TEST1_0_2_Ur_Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoHigh), Ur_Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoHigh), Ur_Ch1) value

    member x.Var_TEST1_0_2_WORK1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoHigh), WORK1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoHigh), WORK1) value

    member x.Var_TEST1_0_2_REF1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoHigh), REF1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoHigh), REF1) value

    member x.Var_TEST1_0_2_CCh1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoHigh), CCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoHigh), CCh1) value

    member x.Var_TEST1_0_2_CoutCh1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoHigh), CoutCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleBeg, TermoHigh), CoutCh1) value

    member x.Var_TEST1_1_0_TppCh1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoLow), TppCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoLow), TppCh1) value

    member x.Var_TEST1_1_0_Var1Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoLow), Var1Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoLow), Var1Ch1) value

    member x.Var_TEST1_1_0_Var2Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoLow), Var2Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoLow), Var2Ch1) value

    member x.Var_TEST1_1_0_Var3Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoLow), Var3Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoLow), Var3Ch1) value

    member x.Var_TEST1_1_0_Uw_Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoLow), Uw_Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoLow), Uw_Ch1) value

    member x.Var_TEST1_1_0_Ur_Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoLow), Ur_Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoLow), Ur_Ch1) value

    member x.Var_TEST1_1_0_WORK1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoLow), WORK1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoLow), WORK1) value

    member x.Var_TEST1_1_0_REF1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoLow), REF1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoLow), REF1) value

    member x.Var_TEST1_1_0_CCh1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoLow), CCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoLow), CCh1) value

    member x.Var_TEST1_1_0_CoutCh1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoLow), CoutCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoLow), CoutCh1) value

    member x.Var_TEST1_1_1_TppCh1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoNorm), TppCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoNorm), TppCh1) value

    member x.Var_TEST1_1_1_Var1Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoNorm), Var1Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoNorm), Var1Ch1) value

    member x.Var_TEST1_1_1_Var2Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoNorm), Var2Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoNorm), Var2Ch1) value

    member x.Var_TEST1_1_1_Var3Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoNorm), Var3Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoNorm), Var3Ch1) value

    member x.Var_TEST1_1_1_Uw_Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoNorm), Uw_Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoNorm), Uw_Ch1) value

    member x.Var_TEST1_1_1_Ur_Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoNorm), Ur_Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoNorm), Ur_Ch1) value

    member x.Var_TEST1_1_1_WORK1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoNorm), WORK1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoNorm), WORK1) value

    member x.Var_TEST1_1_1_REF1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoNorm), REF1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoNorm), REF1) value

    member x.Var_TEST1_1_1_CCh1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoNorm), CCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoNorm), CCh1) value

    member x.Var_TEST1_1_1_CoutCh1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoNorm), CoutCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoNorm), CoutCh1) value

    member x.Var_TEST1_1_2_TppCh1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoHigh), TppCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoHigh), TppCh1) value

    member x.Var_TEST1_1_2_Var1Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoHigh), Var1Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoHigh), Var1Ch1) value

    member x.Var_TEST1_1_2_Var2Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoHigh), Var2Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoHigh), Var2Ch1) value

    member x.Var_TEST1_1_2_Var3Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoHigh), Var3Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoHigh), Var3Ch1) value

    member x.Var_TEST1_1_2_Uw_Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoHigh), Uw_Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoHigh), Uw_Ch1) value

    member x.Var_TEST1_1_2_Ur_Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoHigh), Ur_Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoHigh), Ur_Ch1) value

    member x.Var_TEST1_1_2_WORK1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoHigh), WORK1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoHigh), WORK1) value

    member x.Var_TEST1_1_2_REF1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoHigh), REF1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoHigh), REF1) value

    member x.Var_TEST1_1_2_CCh1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoHigh), CCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoHigh), CCh1) value

    member x.Var_TEST1_1_2_CoutCh1
        with get () = x.getVarUi (Test(Sens2, ScaleMid, TermoHigh), CoutCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleMid, TermoHigh), CoutCh1) value

    member x.Var_TEST1_2_0_TppCh1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoLow), TppCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoLow), TppCh1) value

    member x.Var_TEST1_2_0_Var1Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoLow), Var1Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoLow), Var1Ch1) value

    member x.Var_TEST1_2_0_Var2Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoLow), Var2Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoLow), Var2Ch1) value

    member x.Var_TEST1_2_0_Var3Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoLow), Var3Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoLow), Var3Ch1) value

    member x.Var_TEST1_2_0_Uw_Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoLow), Uw_Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoLow), Uw_Ch1) value

    member x.Var_TEST1_2_0_Ur_Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoLow), Ur_Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoLow), Ur_Ch1) value

    member x.Var_TEST1_2_0_WORK1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoLow), WORK1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoLow), WORK1) value

    member x.Var_TEST1_2_0_REF1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoLow), REF1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoLow), REF1) value

    member x.Var_TEST1_2_0_CCh1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoLow), CCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoLow), CCh1) value

    member x.Var_TEST1_2_0_CoutCh1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoLow), CoutCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoLow), CoutCh1) value

    member x.Var_TEST1_2_1_TppCh1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoNorm), TppCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoNorm), TppCh1) value

    member x.Var_TEST1_2_1_Var1Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoNorm), Var1Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoNorm), Var1Ch1) value

    member x.Var_TEST1_2_1_Var2Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoNorm), Var2Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoNorm), Var2Ch1) value

    member x.Var_TEST1_2_1_Var3Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoNorm), Var3Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoNorm), Var3Ch1) value

    member x.Var_TEST1_2_1_Uw_Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoNorm), Uw_Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoNorm), Uw_Ch1) value

    member x.Var_TEST1_2_1_Ur_Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoNorm), Ur_Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoNorm), Ur_Ch1) value

    member x.Var_TEST1_2_1_WORK1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoNorm), WORK1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoNorm), WORK1) value

    member x.Var_TEST1_2_1_REF1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoNorm), REF1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoNorm), REF1) value

    member x.Var_TEST1_2_1_CCh1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoNorm), CCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoNorm), CCh1) value

    member x.Var_TEST1_2_1_CoutCh1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoNorm), CoutCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoNorm), CoutCh1) value

    member x.Var_TEST1_2_2_TppCh1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoHigh), TppCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoHigh), TppCh1) value

    member x.Var_TEST1_2_2_Var1Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoHigh), Var1Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoHigh), Var1Ch1) value

    member x.Var_TEST1_2_2_Var2Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoHigh), Var2Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoHigh), Var2Ch1) value

    member x.Var_TEST1_2_2_Var3Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoHigh), Var3Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoHigh), Var3Ch1) value

    member x.Var_TEST1_2_2_Uw_Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoHigh), Uw_Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoHigh), Uw_Ch1) value

    member x.Var_TEST1_2_2_Ur_Ch1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoHigh), Ur_Ch1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoHigh), Ur_Ch1) value

    member x.Var_TEST1_2_2_WORK1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoHigh), WORK1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoHigh), WORK1) value

    member x.Var_TEST1_2_2_REF1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoHigh), REF1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoHigh), REF1) value

    member x.Var_TEST1_2_2_CCh1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoHigh), CCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoHigh), CCh1) value

    member x.Var_TEST1_2_2_CoutCh1
        with get () = x.getVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoHigh), CoutCh1)
        and set value = x.setVarUi (Test(Sens2, ScaleEdge ScaleEnd, TermoHigh), CoutCh1) value

    member x.Var_PT0_TppCh0
        with get () = x.getVarUi (TermoPressPt(TermoLow), TppCh0)
        and set value = x.setVarUi (TermoPressPt(TermoLow), TppCh0) value

    member x.Var_PT0_VdatP
        with get () = x.getVarUi (TermoPressPt(TermoLow), VdatP)
        and set value = x.setVarUi (TermoPressPt(TermoLow), VdatP) value

    member x.Var_PT1_TppCh0
        with get () = x.getVarUi (TermoPressPt(TermoNorm), TppCh0)
        and set value = x.setVarUi (TermoPressPt(TermoNorm), TppCh0) value

    member x.Var_PT1_VdatP
        with get () = x.getVarUi (TermoPressPt(TermoNorm), VdatP)
        and set value = x.setVarUi (TermoPressPt(TermoNorm), VdatP) value

    member x.Var_PT2_TppCh0
        with get () = x.getVarUi (TermoPressPt(TermoHigh), TppCh0)
        and set value = x.setVarUi (TermoPressPt(TermoHigh), TppCh0) value

    member x.Var_PT2_VdatP
        with get () = x.getVarUi (TermoPressPt(TermoHigh), VdatP)
        and set value = x.setVarUi (TermoPressPt(TermoHigh), VdatP) value

    member x.ConcError0_0_0 = x.GetConcError (Sens1,ScaleEdge ScaleBeg,TermoLow)

    member x.ConcError0_0_1 = x.GetConcError (Sens1,ScaleEdge ScaleBeg,TermoNorm)

    member x.ConcError0_0_2 = x.GetConcError (Sens1,ScaleEdge ScaleBeg,TermoHigh)

    member x.ConcError0_1_0 = x.GetConcError (Sens1,ScaleMid,TermoLow)

    member x.ConcError0_1_1 = x.GetConcError (Sens1,ScaleMid,TermoNorm)

    member x.ConcError0_1_2 = x.GetConcError (Sens1,ScaleMid,TermoHigh)

    member x.ConcError0_2_0 = x.GetConcError (Sens1,ScaleEdge ScaleEnd,TermoLow)

    member x.ConcError0_2_1 = x.GetConcError (Sens1,ScaleEdge ScaleEnd,TermoNorm)

    member x.ConcError0_2_2 = x.GetConcError (Sens1,ScaleEdge ScaleEnd,TermoHigh)

    member x.ConcError1_0_0 = x.GetConcError (Sens2,ScaleEdge ScaleBeg,TermoLow)

    member x.ConcError1_0_1 = x.GetConcError (Sens2,ScaleEdge ScaleBeg,TermoNorm)

    member x.ConcError1_0_2 = x.GetConcError (Sens2,ScaleEdge ScaleBeg,TermoHigh)

    member x.ConcError1_1_0 = x.GetConcError (Sens2,ScaleMid,TermoLow)

    member x.ConcError1_1_1 = x.GetConcError (Sens2,ScaleMid,TermoNorm)

    member x.ConcError1_1_2 = x.GetConcError (Sens2,ScaleMid,TermoHigh)

    member x.ConcError1_2_0 = x.GetConcError (Sens2,ScaleEdge ScaleEnd,TermoLow)

    member x.ConcError1_2_1 = x.GetConcError (Sens2,ScaleEdge ScaleEnd,TermoNorm)

    member x.ConcError1_2_2 = x.GetConcError (Sens2,ScaleEdge ScaleEnd,TermoHigh)

    member x.CCh0 = x.getPhysVarValueUi(CCh0)

    member x.CCh1 = x.getPhysVarValueUi(CCh1)

    member x.CCh2 = x.getPhysVarValueUi(CCh2)

    member x.PkPa = x.getPhysVarValueUi(PkPa)

    member x.Pmm = x.getPhysVarValueUi(Pmm)

    member x.Tmcu = x.getPhysVarValueUi(Tmcu)

    member x.Vbat = x.getPhysVarValueUi(Vbat)

    member x.Vref = x.getPhysVarValueUi(Vref)

    member x.Vmcu = x.getPhysVarValueUi(Vmcu)

    member x.VdatP = x.getPhysVarValueUi(VdatP)

    member x.CoutCh0 = x.getPhysVarValueUi(CoutCh0)

    member x.TppCh0 = x.getPhysVarValueUi(TppCh0)

    member x.ILOn0 = x.getPhysVarValueUi(ILOn0)

    member x.ILOff0 = x.getPhysVarValueUi(ILOff0)

    member x.Uw_Ch0 = x.getPhysVarValueUi(Uw_Ch0)

    member x.Ur_Ch0 = x.getPhysVarValueUi(Ur_Ch0)

    member x.WORK0 = x.getPhysVarValueUi(WORK0)

    member x.REF0 = x.getPhysVarValueUi(REF0)

    member x.Var1Ch0 = x.getPhysVarValueUi(Var1Ch0)

    member x.Var2Ch0 = x.getPhysVarValueUi(Var2Ch0)

    member x.Var3Ch0 = x.getPhysVarValueUi(Var3Ch0)

    member x.FppCh0 = x.getPhysVarValueUi(FppCh0)

    member x.CoutCh1 = x.getPhysVarValueUi(CoutCh1)

    member x.TppCh1 = x.getPhysVarValueUi(TppCh1)

    member x.ILOn1 = x.getPhysVarValueUi(ILOn1)

    member x.ILOff1 = x.getPhysVarValueUi(ILOff1)

    member x.Uw_Ch1 = x.getPhysVarValueUi(Uw_Ch1)

    member x.Ur_Ch1 = x.getPhysVarValueUi(Ur_Ch1)

    member x.WORK1 = x.getPhysVarValueUi(WORK1)

    member x.REF1 = x.getPhysVarValueUi(REF1)

    member x.Var1Ch1 = x.getPhysVarValueUi(Var1Ch1)

    member x.Var2Ch1 = x.getPhysVarValueUi(Var2Ch1)

    member x.Var3Ch1 = x.getPhysVarValueUi(Var3Ch1)

    member x.FppCh1 = x.getPhysVarValueUi(FppCh1)
