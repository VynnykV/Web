let n = parseInt(prompt("Введіть кількість елементів масиву"));
if(!NaN&&Number.isInteger(n)&&n>0)
{
    let A = FillArray(n);
    let B = BuildArray(A);
    let newB = insertionSort(B.slice());
    let result = document.getElementById("result");
    result.innerText = "Згенерований масив\n"+A.join(' ')+"\nПерероблений\n"+B.join(' ')+"\nВідсортований\n"+newB.join(' ');
}
else alert("Ай, карамба");

function FillArray(n){
    let array = new Array(n);
    for(let i = 0; i<n;i++){
        array[i] = Math.floor(Math.random() * 101); 
    }
    return array;
}

function FindMax(array){
    let max = array[0];
    array.forEach(element => {
        if(max<element){
            max=element;
        }
    });
    return max;
}

function BuildArray(array){
    let newArray = new Array();
    let max = FindMax(array);
    array.forEach(element => {
        newArray.push(max*element);
    });
    return newArray;
}

function insertionSort(inputArr) {
    let n = inputArr.length;
        for (let i = 1; i < n; i++) {
            let current = inputArr[i];
            let j = i-1; 
            while ((j > -1) && (current > inputArr[j])) {
                inputArr[j+1] = inputArr[j];
                j--;
            }
            inputArr[j+1] = current;
        }
    return inputArr;
}