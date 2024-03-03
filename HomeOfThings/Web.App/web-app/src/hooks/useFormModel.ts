import React from "react"

const useFormModel = <T>(initialState:T, validationCallBack?: (model: T) => boolean) =>{
    const originalRef = React.useRef<T | null>(null)

    const [model, setModel] = React.useState<T>(initialState)
    const [isValidModel, setIsValidModel] = React.useState<boolean>(false)

    React.useEffect(() =>{
        originalRef.current = initialState
    },[initialState])

    const changesApplied = React.useMemo(() =>{
        return JSON.stringify(model) !== JSON.stringify(originalRef.current)
    },[model])

    const canSave = React.useMemo(() =>{
        return changesApplied && isValidModel
    },[changesApplied, isValidModel])

    const handleTextChange = React.useCallback((e: React.ChangeEvent<HTMLInputElement>, property: keyof T) => {
        console.log("CHANGE")
        const update: T = {...model, [property]: e.currentTarget.value as string}
        setModel(update)
        
        if(validationCallBack !== undefined){
            setIsValidModel(validationCallBack(update))
        }
    },[model, validationCallBack])

    const handleReset = React.useCallback(() =>{
        setModel(originalRef?.current?? {} as T)
    },[])

    return {
        model,
        isValidModel,
        changesApplied,
        canSave,
        handleTextChange,
        handleReset
    }
    

}

export default useFormModel