module DataTypes.EstimadoresDeRegresionL

type EstimadoresReg = {
    Producto: string;
    Ecuacion: string;
    Pendiente: float;
    EjeY: float;
    MAE: float;
    RMSE: float;
    CoeficienteDeDeterminacion: float
}