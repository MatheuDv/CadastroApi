document.addEventListener("DOMContentLoaded", function(){
   
    const pessoalista = document.getElementById('pessoa-lista');
 
    function renderTable(data){
        pessoalista.innerHTML = "";
       
        data.forEach(pessoa =>{
            const row = document.createElement('tr');
 
            row.innerHTML = `
                <td>${pessoa.pessoaId}</td>
                <td>${pessoa.primeiroNome}</td>
                <td>${pessoa.nomeMeio}</td>
                <td>${pessoa.ultimoNome}</td>
                <td>${pessoa.cpf}</td>
                <td>
                    <button>Editar</button>
                    <button>Excluir</button>
                </td>
            `
            pessoalista.appendChild(row)
        })
    }
 
    function feachPessoas(){
        fetch("https://localhost:7059/api/Pessoas/GetAll")
        .then(response => response.json())
        .then(data => renderTable(data))
        .catch(error => console.error("Erro ao buscar dados da Api"))
    }
    feachPessoas();
})

function abrirTelaCreate(){
    window.location.href = '../pages/create.html';
}
function excluirPessoa(pessoaId) {
    if (confirm("Deseja realmente excluir esta pessoa?")) {
        fetch(`https://localhost:7059/api/Pessoas/DeleteById/${pessoaId}`, {
            method: "DELETE",
            headers: {
                "Content-Type": "application/json",
                
            },
        })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                alert("Pessoa excluída com sucesso.");
                feachPessoas(); 
            } else {
                alert("Falha ao excluir a pessoa: " + data.message);
            }
        })
        .catch(error => {
            console.error("Erro ao realizar a exclusão:", error);
        });
    }
}
