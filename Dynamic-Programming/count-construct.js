
const countConstruct = (target, wordBank, memo={})=> {
    let totalCount=0;
    for (let word of wordBank){
        if (target.indexOf(word)===0){
            const numWaysForRest= countConstruct (target.slice(word.length), wordBank, memo);
            totalCount+= numWaysForRest;
        }
    }

    memo[target]= totalCount;
    return totalCount;
}