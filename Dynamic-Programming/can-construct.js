const canConstruct=(target, wordBank)=> {
    console.log (target)
    if (target === '') return true;

    for (let word of wordBank){
        console.log (word)
        if (target.indexOf(word)==0){
            
            const suffix = target.slice(word.length);
            if (canConstruct(suffix, wordBank)===true){
                return true;
            }
        }
    }

    return false;
}


// console.log (canConstruct("abcdef", ["ab","abc","cd","def","abcd"]))
// console.log (canConstruct("skateboard", ["bo","rd","ate","t","ska","sk","boar"]))
console.log (canConstruct("enterapotentpot", ["a","p","ent","enter","ot","o","t"]))
// console.log (canConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", 
// ["e",
//     "ee",
//     "eee",
//     "eeee",
//     "eeeee",
//     "eeeeee",
// ]))

//console.log ("abcdef".slice("ab".length))