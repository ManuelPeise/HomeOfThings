export const isValidEmail = (email:string) =>{
    const regex = new RegExp("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$")

    return regex.test(email)
}

export const ensureSeparator = (value: string) =>{
    return value.replace(",", ".")
}

export const enforceNumberValue = (inputValue: string) => {
    const value = ensureSeparator(inputValue)

    const fields = value.split(".")

    if(fields.length > 1 && fields[1].length === 0){
        return `${value}00`
    }
    return value
}

export const isNumberInput = (inputValue: string) => {
      const enforcedValue = enforceNumberValue(inputValue);
      const isNumber = !isNaN(Number(enforcedValue));
      return {
        isNumber,
        enforcedValue,
        inputValue
      };
}

export const isValidNumber = (value: string) =>{
    const fields = value.split(".")

    if(fields.length > 1 && fields[1].length > 0){
        return true;
    }

    return false;
}
   
