#!/usr/bin/env bash
#
# primeiro-script.sh
#
# Titulo:       Guia basico DynanoDB.
# Autor:        Werter Bonfim
# Manutenção:   Werter Bonfim
# Site:         https://github.com/WerterBonfim
# Data:         30-08-2021
# Versão:       1.0.0

# Exit codes
# ==========
# 0   no error
# 1   script interrupted
# 2   error description

#
# ------------------------------------------------------------------------ #
#  Este programa serve de guia para criação de recusos no DynamoDB.
#
#  Exemplos:
#      $ ./primeiro-script.sh --tabela
#      Neste exemplo o script ira cria uma tabela simples chamada pessoas
# ------------------------------------------------------------------------ #
# Histórico:
#
#   v1.0 30/08/21, Werter:
#       - Início do programa
# ------------------------------------------------------------------------ #
# Testado em:
#   bash 4.4.19
# ------------------------------------------------------------------------ #

# ------------------------------- VARIÁVEIS ------------------------------ #

urlDynamoDB="http://localhost:7000"

menuInterativo="
    $(basename "$0") - [OPÇÕES]

    -h - menu de ajuda
    --listar-tabelas - lista as tabelas
    --criar-tabela [nome da tabela] - cria uma tabela
"

# ------------------------------------------------------------------------ #

# ------------------------------- FUNÇÕES ----------------------------------------- #

function criarTabela() {

    aws dynamodb create-table \
        --table-name Music \
        --attribute-definitions \
        AttributeName=Artist,AttributeType=S \
        AttributeName=SongTitle,AttributeType=S \
        --key-schema AttributeName=Artist,KeyType=HASH AttributeName=SongTitle,KeyType=RANGE \
        --provisioned-throughput ReadCapacityUnits=1,WriteCapacityUnits=1
}

function listarTabelas() {

    aws dynamodb list-tables --endpoint-url "$urlDynamoDB"

}

# --------------------------------------------------------------------------------- #

# ------------------------------- EXECUÇÃO ----------------------------------------- #

# stric mode
set -euo pipefail

# Verifica se SDK aws esta instalado
[[ $(type -P aws) ]] || {
    echo "Necessito do AWS CLI para continuar"
}

[ -z "${1-}" ] && {
    echo "Comando inválido"
    echo "$menuInterativo"
    exit 0
}

case "$1" in
-h)
    echo "$menuInterativo" && exit 0
    ;;
--listar-tabelas)

    listarTabelas && exit 0
    ;;

--criar-tabela)
    criar-tabela && exit 0
    ;;
*)
    echo "Opção inválida, valie o -h" && exit 1
    ;;
esac
