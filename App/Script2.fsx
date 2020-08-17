#r @"C:\DOTNETPATH\src\github.com\AnkatMICRO\NumericMethod\bin\DEbug\NumericMethod.dll"

let x = [| 0.000985M; 2.97849M; 3.91042M; 4.7168M |]
let y = [| 0M; 1.219M; 2.51M; 4.85M |]

let interpolate = NumericMethod.LinearAlgebraicEquationsSystem.InterpolateRational4

interpolate(x,y)