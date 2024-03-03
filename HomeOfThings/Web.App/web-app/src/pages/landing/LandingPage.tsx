import { useStatelessApi } from "../../hooks/api/useStatelessApi"
import  useFormModel  from "../../hooks/useFormModel"

interface ITest{
    name: string
    age: number
}
const LandingPage: React.FC = () =>{

    const {model, handleChange, handleReset} = useFormModel<ITest>({name: "", age: 0})

    console.log(model)

    return(
        <div>
        <div>{process.env.REACT_APP_TITLE}</div>
        <div>
            <input type="text" value={model.name} onChange={(e) => handleChange(e, "name")}/>
        </div>
        <div>
            <input type="number" title="test" value={model.age} onChange={(e) => handleChange(e, "age")}/>
        </div>
        <div>
            <button onClick={handleReset}>CANCEL</button>
        </div>
        </div>
    )
}

export default LandingPage