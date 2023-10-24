// Define as constantes verdade e falso para facilitar a conversão de valores booleanos em 1 e 0.
const verdadeiro = 1;
const falso = 0;

// Função que converte valores booleanos em 1 (verdade) ou 0 (falso).
function convertTrueFalse(booleano) {
  return booleano ? verdadeiro : falso;
}

// Função para calcular o resultado de uma linha da tabela verdade com base no conectivo escolhido.
function getResult(linha, conectivo) {
  switch (conectivo) {
    case "NOT":
      linha.push(convertTrueFalse(!linha[0]));
      break;
    case "AND":
      linha.push(convertTrueFalse(linha[0] && linha[1]));
      break;
    case "OR":
      linha.push(convertTrueFalse(linha[0] || linha[1]));
      break;
    case "XOR":
      linha.push(convertTrueFalse(linha[0] !== linha[1]));
      break;
    case "BICONDICIONAL":
      linha.push(convertTrueFalse(linha[0] === linha[1]));
      break;
    case "IMPLICACAO":
      linha.push(convertTrueFalse(!linha[0] || linha[1]));
      break;
    default:
      return;
  }
}

// Função principal que gera a tabela verdade com base no conectivo escolhido pelo usuário.
function gerarTabela() {
  const conectivo = document.getElementById("conectivo").value;
  const tabelaVerdade = document.getElementById("tabela-verdade");
  let conectivoSimbolo;

  // Define o símbolo do conectivo com base na escolha do usuário.
  switch (conectivo) {
    case "NOT":
      conectivoSimbolo = "¬";
      break;
    case "AND":
      conectivoSimbolo = "∧";
      break;
    case "OR":
      conectivoSimbolo = "∨";
      break;
    case "XOR":
      conectivoSimbolo = "⊕";
      break;
    case "BICONDICIONAL":
      conectivoSimbolo = "↔";
      break;
    case "IMPLICACAO":
      conectivoSimbolo = "→";
      break;
    default:
      return;
  }

  // Definição das colunas da tabela, dependendo do conectivo.
  const colunas = [];
  if (conectivo === "NOT") {
    colunas.push(["P", "¬P"]);
  } else {
    colunas.push(["P", "Q", conectivoSimbolo]);
  }

  // Definição dos valores da tabela verdade (falso e verdade) para todas as combinações possíveis.
  const valores = [[falso], [falso], [verdadeiro], [verdadeiro]];

  if (conectivo !== "NOT") {
    valores[0].push(falso);
    valores[1].push(verdadeiro);
    valores[2].push(falso);
    valores[3].push(verdadeiro);
  }

  // Calcula o resultado para cada linha da tabela verdade.
  for (const linha of valores) {
    getResult(linha, conectivo);
  }

  // Cria a tabela verdade em HTML.
  let tabelaHTML = "<table border='1'><tr>";
  for (const coluna of colunas[0]) {
    tabelaHTML += "<th style='padding:5px;'>" + coluna + "</th>";
  }
  tabelaHTML += "</tr>";

  for (const linha of valores) {
    tabelaHTML += "<tr>";
    for (const valor of linha) {
      tabelaHTML += "<td style='padding:5px;'>" + valor + "</td>";
    }
    tabelaHTML += "</tr>";
  }

  tabelaHTML += "</table>";
  tabelaVerdade.innerHTML = tabelaHTML;
}

// Chamar a função inicial ao iniciar a página
gerarTabela();
