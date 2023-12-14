function createPessoa() {
    const primeiroNome = document.getElementById("firstName").value
    const segundoNome = document.getElementById("middleName").value
    const ultimoNome = document.getElementById("lastName").value
    const cpf = document.getElementById("cpf").value

    const data = {
        primeiroNome: primeiroNome,
        nomeMeio: segundoNome,
        ultimoNome: ultimoNome,
        cpf: cpf,
    }
fetch('https://localhost:7059/api/Pessoas/Create', {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
}).then(response =>{
    if (!response.ok){
        alert("Erro ao Criar Pessoa");
    }
    alert("Pessoa Criada com Sucesso !");
    window.location.href = '../css/index.html';
})
}